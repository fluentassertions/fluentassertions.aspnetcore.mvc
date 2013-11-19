#Project Description

FluentAssertions MVC is a set of MVC focused assertions and helper extensions to the excellent [FluentAssertions][fa-home] library.

## Installation

For MVC 4 or 5 projects, add the [MVC 4][nuget-mvc4] NuGet package to your unit test project:

````
PM> Install-Package FluentAssertions.Mvc4
````
There is also an [MVC 3][nuget-mvc3] package:
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

## Continuous Integration

The [build][1] is generously hosted and run on the [CodeBetter TeamCity][2] infrastructure, courtesy of [JetBrains](http://www.jetbrains.com/).

|  | Status of last build |
| :------ | :------: |
| **master** | [![master][3]][4] |
 
 [1]: http://teamcity.codebetter.com/project.html?projectId=project396&guest=1
 [2]: http://codebetter.com/codebetter-ci/
 [3]: http://teamcity.codebetter.com/app/rest/builds/buildType:(id:bt1090)/statusIcon
 [4]: http://teamcity.codebetter.com/viewType.html?buildTypeId=bt1090&guest=1

![YouTrack and TeamCity](http://www.jetbrains.com/img/banners/Codebetter300x250.png)

[fa-home]: https://github.com/dennisdoomen/FluentAssertions
[fa-frameworks]: https://github.com/dennisdoomen/fluentassertions/wiki/Documentation#supported-test-frameworks
[nuget-mvc3]: https://www.nuget.org/packages/FluentAssertions.Mvc3
[nuget-mvc4]: https://www.nuget.org/packages/FluentAssertions.Mvc4
