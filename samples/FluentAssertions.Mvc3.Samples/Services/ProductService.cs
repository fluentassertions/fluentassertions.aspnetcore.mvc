using System.Collections.Generic;
using FluentAssertions.Mvc.Samples.Models;

namespace FluentAssertions.Mvc.Samples.Services
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