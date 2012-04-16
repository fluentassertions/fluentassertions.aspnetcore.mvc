using FluentAssertions.Mvc3.Samples.Controllers;
using NUnit.Framework;

namespace FluentAssertions.Mvc3.Samples.Tests
{
    [TestFixture]
    public class ProductController_Tests
    {
        [Test]
		public void List_ShouldReturnView()
		{
            var controller = new ProductController();
            controller.List().Should()
                .BeView()
                .WithViewName("Index");
		}
    }
}