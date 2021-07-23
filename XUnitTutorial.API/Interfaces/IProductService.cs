using System;
using System.Collections.Generic;
using XUnitTutorial.API.Models;

namespace XUnitTutorial.API.Interfaces
{
    public interface IProductService
    {
        void AddProductToCart(Product product);

        IEnumerable<Product> GetAllProduct();
    }
}
