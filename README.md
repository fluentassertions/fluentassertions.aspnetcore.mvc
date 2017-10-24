# Fluent Assertions for ASP.NET Core MVC
[![Build status](https://ci.appveyor.com/api/projects/status/rt5vutjvy2no75cv?svg=true)](https://ci.appveyor.com/project/kevinkuszyk/fluentassertions-aspnetcore-mvc)

This repro contains the Fluent Assertions extensions for ASP.NET Core MVC.  It is maintained by [@kevinkuszyk](https://github.com/kevinkuszyk).

## Installation

Add the NuGet package to your test project.

Add the [Fluent Assertions for MVC Core][nuget-mvc-core] NuGet package to your unit test project:

````
PM> FluentAssertions.AspNetCore.Mvc
````

## Getting Started

Write a unit test for your controller using one of the [supported test frameworks][fa-frameworks].  For exampe with NUnit:

```` C#
[Test]
public void Index_Action_Returns_View()
{
    // Arrange
    var controller = new HomeController();

    // Act
    var result = controller.Index();

    // Assert
    result.Should().BeViewResult();
}

````

## Building

Simply clone this repro and build the `FluentAssertions.AspNetCore.Mvc.sln` solution.

[fa-frameworks]: https://github.com/dennisdoomen/fluentassertions/wiki/Documentation#supported-test-frameworks
[nuget-mvc-core]: https://www.nuget.org/packages/FluentAssertions.AspNetCore.Mvc
