using Shop.Api.Reads;
using Shop.Infrastructure.Reads;

namespace Shop.Api.Graphs.Queries.Products;

[ExtendObjectType("Query")]
public class ProductQuery
{
    // [UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 10)]
    [UseFiltering]
    public IEnumerable<ProductReadModel> Products(
        [Service] ApplicationDbContextReadOnly context)
        => context.ProductReadModels;
}