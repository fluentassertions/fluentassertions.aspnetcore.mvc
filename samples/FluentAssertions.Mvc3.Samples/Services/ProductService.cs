using System.Collections.Generic;
using FluentAssertions.Mvc3.Samples.Models;

namespace FluentAssertions.Mvc3.Samples.Services
{
    public class ProductService : IProductService
    {
        public IEnumerable<ProductViewModel> GetProducts()
        {
            return new ProductViewModel[]
            {
                new ProductViewModel { Id = 1, Name = "Blue Duck" },
                new ProductViewModel { Id = 2, Name = "Red Duck" }
            };
        }
    }
}