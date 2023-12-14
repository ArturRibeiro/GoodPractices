namespace Shop.Infrastructure.Reads.Models;

public record ProductReadModel
(
    int Id,
    string Name,
    string Description,
    decimal UnitPrice,
    int QuantityInStock
);