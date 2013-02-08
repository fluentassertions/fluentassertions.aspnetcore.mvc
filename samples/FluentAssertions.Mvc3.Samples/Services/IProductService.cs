using System.Collections.Generic;
using FluentAssertions.Mvc.Samples.Models;

namespace FluentAssertions.Mvc.Samples.Services
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetProducts();
    }
}
