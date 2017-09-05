using System.Collections.Generic;
using FluentAssertions.AspNetCore.Mvc.Sample.Models;

namespace FluentAssertions.AspNetCore.Mvc.Sample.Services
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetProducts();
    }
}
