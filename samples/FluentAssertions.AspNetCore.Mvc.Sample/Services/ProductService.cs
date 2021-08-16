using FluentAssertions.AspNetCore.Mvc.Sample.Models;
using System.Collections.Generic;

namespace FluentAssertions.AspNetCore.Mvc.Sample.Services
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