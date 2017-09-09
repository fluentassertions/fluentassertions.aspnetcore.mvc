using FluentAssertions.AspNetCore.Mvc.Sample.Controllers;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Sample.Tests
{
    public class ProductController_Tests
    {
        [Fact]
		public void List_ShouldReturnView()
		{
            var controller = new ProductController();
		    controller.List().Should()
                .BeViewResult()
                .WithViewName("Index");
		}
    }
}