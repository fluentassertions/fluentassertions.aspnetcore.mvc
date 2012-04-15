using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentAssertions.Mvc3.Samples.Models;

namespace FluentAssertions.Mvc3.Samples.Services
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetProducts();
    }
}
