using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Models
{
    public class ProductModel
    {
        public List<Product> Products;

        public ProductModel()
        {
            this.Products = new List<Product>() {
                new Product {
                    Id = "0",
                    Name = "Gold Coin",
                    Price = 5.99,
                },
                new Product {
                    Id = "1",
                    Name = "Silver Coin",
                    Price = 3.99,
                },
                new Product {
                    Id = "2",
                    Name = "Copper Coin",
                    Price = 1.99,
                }
            };
        }

        public List<Product> FindAll()
        {
            return this.Products;
        }

        public Product Find(string id)
        {
            return this.Products.Single(p => p.Id.Equals(id));
        }
    }
}
