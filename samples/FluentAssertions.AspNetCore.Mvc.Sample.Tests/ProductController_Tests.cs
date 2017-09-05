using FluentAssertions.AspNetCore.Mvc.Sample.Controllers;
using NUnit.Framework;

namespace FluentAssertions.AspNetCore.Mvc.Sample.Tests
{
    [TestFixture]
    public class ProductController_Tests
    {
        [Test]
		public void List_ShouldReturnView()
		{
            var controller = new ProductController();
		    controller.List().Should()
                .BeViewResult()
                .WithViewName("Index");
		}
    }
}