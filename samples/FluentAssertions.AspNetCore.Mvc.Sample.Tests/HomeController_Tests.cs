using FluentAssertions.AspNetCore.Mvc.Sample.Controllers;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Sample.Tests
{
    public class HomeController_Tests
    {
        #region Public Methods

        [Fact]
        public void Index_ShouldReturnDefaultView()
        {
            var controller = new HomeController();
            controller.Index().Should()
                .BeViewResult().WithDefaultViewName();
        }

        #endregion Public Methods
    }
}