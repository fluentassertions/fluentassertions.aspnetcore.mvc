# Project Description
[![Build status](https://ci.appveyor.com/api/projects/status/rt5vutjvy2no75cv?svg=true)](https://ci.appveyor.com/project/kevinkuszyk/fluentassertions-aspnetcore-mvc)

Fluent Assertions for MVC Core is a set of MVC Core focused assertions and helper extensions to the excellent [Fluent Assertions][fa-home] library.

## Installation

Add the NuGet package which matches the version of MVC you are using to your test project.

Add the [Fluent Assertions for MVC Core][nuget-mvc-core] NuGet package to your unit test project:

````
PM> FluentAssertions.AspNetCore.Mvc -Pre
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

[fa-home]: https://github.com/dennisdoomen/FluentAssertions
[fa-frameworks]: https://github.com/dennisdoomen/fluentassertions/wiki/Documentation#supported-test-frameworks
[nuget-mvc-core]: https://www.nuget.org/packages/FluentAssertions.AspNetCore.Mvc
