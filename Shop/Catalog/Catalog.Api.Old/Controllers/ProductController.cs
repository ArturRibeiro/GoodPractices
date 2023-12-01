using Bogus;
using Catalog.Api.ReadModels;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    // GET
    [HttpGet(Name = "Products")]
    public IActionResult Index()
    {
        var productGenerator = new Faker<Product>()
            .RuleFor(p => p.Id, f => f.IndexFaker)
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
            .RuleFor(p => p.Price, f => Math.Round(f.Random.Decimal(1, 1000), 2))
            .RuleFor(p => p.QuantityInStock, f => f.Random.Number(1, 100));
        
        var products = productGenerator.Generate(10);
        
        return Ok(products);
    }
}