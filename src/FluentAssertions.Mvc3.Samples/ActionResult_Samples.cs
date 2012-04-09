using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using FluentAssertions.Mvc3.Samples.Controllers;
using FluentAssertions.Mvc3;
using FluentAssertions.Mvc3.Samples.Models;

namespace FluentAssertions.Mvc3.Samples
{
    public class ActionResult_Samples
    {
        public void ViewResult_Sample()
        {
            var controller = new HomeController();
            var result = controller.Index();

            result.Should().BeView()
                    .WithViewName("Start")
                    .WithTempData("Message", "Welcome")
                    .ModelAs<WelcomeModel>().UserName.Should().Be("Jonny Briggs");
        }
    }
}
