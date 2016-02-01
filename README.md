# Project Description
[![Build status](https://ci.appveyor.com/api/projects/status/wlt5yp8m66y9rw4f?svg=true)](https://ci.appveyor.com/project/kevinkuszyk/fluentassertions-mvc)

FluentAssertions MVC is a set of MVC focused assertions and helper extensions to the excellent [FluentAssertions][fa-home] library.

## Installation

Add the NuGet package which matches the version of MVC you are using to your test project.

### MVC 5

Add the [MVC 5][nuget-mvc5] NuGet package to your unit test project:

````
PM> Install-Package FluentAssertions.Mvc5
````

### MVC 4

Add the [MVC 4][nuget-mvc4] NuGet package to your unit test project:

````
PM> Install-Package FluentAssertions.Mvc4
````

### MVC 3

Add the [MVC 3][nuget-mvc3] NuGet package to your unit test project:

````
PM> Install-Package FluentAssertions.Mvc3
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
[nuget-mvc3]: https://www.nuget.org/packages/FluentAssertions.Mvc3
[nuget-mvc4]: https://www.nuget.org/packages/FluentAssertions.Mvc4
[nuget-mvc5]: https://www.nuget.org/packages/FluentAssertions.Mvc5
