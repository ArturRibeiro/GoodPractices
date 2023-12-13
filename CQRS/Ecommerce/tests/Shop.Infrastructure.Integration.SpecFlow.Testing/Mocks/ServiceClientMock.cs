using Shop.Api.Reads;
using Shop.Application.Checkouts;
using Shop.Application.Checkouts.Imp;

namespace Shop.Infrastructure.Integration.SpecFlow.Testing.Mocks
{
    public class ServiceClientMock : IServiceClient
    {
        private readonly ApplicationDbContextReadOnly _contextReadOnly;

        public ServiceClientMock(ApplicationDbContextReadOnly contextReadOnly)
        {
            _contextReadOnly = contextReadOnly;
        }

        public async Task<IEnumerable<ProductMessageResponse>> GetProductPrices(ProductMessageRequest[] products)
        {
            var ids = products.Select(x => x.Id).ToArray();

            var productReadModels = _contextReadOnly.ProductReadModels.Where(x => ids.Contains(x.Id)).ToList();
            
            return from productReadModel in productReadModels
                join productMessageResponse in products
                    on productReadModel.Id equals productMessageResponse.Id
                select new ProductMessageResponse(productReadModel.Id
                    , productReadModel.UnitPrice
                    , productMessageResponse.Quantity);
        }
    }
}