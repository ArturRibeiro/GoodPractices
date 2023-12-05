namespace Shop.Api.Graphs.Queries.Products;

[ExtendObjectType("Query")]
public class ProductQuery
{
    // [UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 10)]
    // [UseFiltering]
    public IEnumerable<ProductReadModel> Products() =>
        new Faker<ProductReadModel>()
            .RuleFor(p => p.Id, f => f.IndexFaker)
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
            .RuleFor(p => p.Price, f => Math.Round(f.Random.Decimal(1, 1000), 2))
            .RuleFor(p => p.QuantityInStock, f => f.Random.Number(1, 100))
            .Generate(30);
}

public class ProductReadModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }
}
