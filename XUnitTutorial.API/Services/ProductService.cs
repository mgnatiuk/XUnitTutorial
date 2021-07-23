using System;
using System.Collections.Generic;
using XUnitTutorial.API.Interfaces;
using XUnitTutorial.API.Models;

namespace XUnitTutorial.API.Services
{
    public class ProductService : IProductService
    {
        private List<Product> Products { get; set; }

        public ProductService()
        {
            Products = new List<Product>() {
                new Product(1,"IPhone"),
                new Product(2,"MacBook"),
                new Product(3,"AirTag")
            };
        }

        public void AddProductToCart(Product product)
        {
            if (product == null)
                throw new ArgumentException("Product is null");

            Products.Add(product);
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return Products;
        }
    }
}
