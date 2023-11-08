using System.Collections.ObjectModel;

namespace Pattern.Functional.Programming.Unit.Testing.Repositorys
{
    public class Person
    {
        public int Id { get; set; }
    }
    
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    
    public class ShoppingCart
    {
        private IList<Product> _products = new List<Product>();
        public int ProductId { get; set; }

        public IReadOnlyCollection<Product> Items => _products.AsReadOnly();

        public void AddProduct(Product product) => _products.Add(product);
    }
    
    public class ShoppingCartService
    {
        private ShoppingCart _cart = new();

        public IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>
            {
                new() { Id = 1, Name = "Produto 1", Price = 10.99m },
                new() { Id = 2, Name = "Produto 2", Price = 15.99m },
            };

            return products;
        }
        
        public ShoppingCart AddToCart(Product? product)
        {
            _cart.AddProduct(product);
            return _cart;
        }
        
        public ShoppingCart GetShoppingCart()
        {
            return _cart;
        }
    }
}