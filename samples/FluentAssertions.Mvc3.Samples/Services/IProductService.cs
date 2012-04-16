using System.Collections.Generic;
using FluentAssertions.Mvc3.Samples.Models;

namespace FluentAssertions.Mvc3.Samples.Services
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetProducts();
    }
}
