using FluentAssertions.AspNetCore.Mvc.Sample.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [Fact]
        public void GetActionResultOfT_OnFalse_Returns_Data()
        {
            var controller = new ProductController();
            var model = new Models.ProductViewModel { Id = 1, Name = "Text" };
            var returnError = false;

            var result = controller.GetActionResultOfT(model, returnError);

            result.Should().BeObjectResult()
                .Value.Should().Be(model);
        }

        [Fact]
        public void GetActionResultOfT_OnTrue_Returns_BadRequest()
        {
            var controller = new ProductController();
            var model = new Models.ProductViewModel { Id = 1, Name = "Text" };
            var returnError = true;

            var result = controller.GetActionResultOfT(model, returnError);

            result.Should().BeConvertibleTo<BadRequestObjectResult>()
                .Which.Value.Should().BeSameAs(model);

            result.Should().BeConvertibleTo<BadRequestObjectResult>()
                .Which.Should().BeBadRequestObjectResult();
        }
    }
}
