namespace Shop.Api.Graphs.Queries.Products;

public class ProductType: ObjectType<ProductReadModel>
{
    protected override void Configure(IObjectTypeDescriptor<ProductReadModel> descriptor)
    {
        descriptor.Name("Product");
        descriptor.Description("Graphql : Product Type");

        descriptor.Field(u => u.Id).Description("Product id");
        descriptor.Field(u => u.Name).Description("Product name");
        descriptor.Field(u => u.Description).Description("Product description");
        descriptor.Field(u => u.UnitPrice).Description("Product price");
        descriptor.Field(u => u.QuantityInStock).Description("Product quantity in stock");
    }
}