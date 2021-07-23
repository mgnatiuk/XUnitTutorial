using System;
namespace XUnitTutorial.API.Models
{
    public class Product
    {
        public long Id { get; private set; }

        public string Name { get; private set; }

        public Product(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
