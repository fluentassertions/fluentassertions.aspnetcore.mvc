using FluentAssertions.AspNetCore.Mvc.Sample.Models;
using System.Collections.Generic;

namespace FluentAssertions.Mvc.Samples.Services
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetProducts();
    }
}
