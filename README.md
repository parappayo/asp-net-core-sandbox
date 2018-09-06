
# asp-net-core-sandbox

A minimal ASP.NET Core web API demo for experimenting. Various learning resources are collected here.

# Advantages

* .NET has a robust ecosystem with some good programming language options including F#.
* Focus on portability looks promising for allowing a variety of hosting options.

# Pitfalls

* The existence of so many ASP.NET versions creates a hall-of-mirrors effect with overlapping docs, namespaces, community posts, examples, best practices, rants, etc. It is hard to know what advice applies to your project, and the history of ASP.NET is obscured by hype and confusing product names.
* Visual Studio is a slow and bloated tool with a lot of bugs. Team members can have local configuration drift that causes issues. Alternatives exist but it is considered the standard IDE for ASP.NET development.
* Creating a project in Visual Studio via New Project -> .NET Core -> ASP.NET Core Web Application versus importing the Microsoft.AspNetCore.All Nuget package into an empty project may give very different results even though both are suggested as valid ways to start a project.
* It is not clear how to debug routing, since so much is handled auto-magically with reflection. Changing the body type of a POST request can route to an unexpected handler. It is best to avoid getting fancy with lots of different endpoint types, but teams in the wild may lack the ability to show such constraint.
* IIS may not be a good fit for your project.

# Concepts

* Attribute Routing - uses C# attributes to denote request handlers; the alternative in ASP.NET is convention-based routing
* Managed Runtime Environment - platform that runs virtual machine code rather than native code, memory management is handled by the VM; .NET is an example of this
* Model-View-Controller (MVC) - a common software design pattern; under .NET Core, controllers are the implementations of service end-points, models are data sources for the controllers, and views are the web pages that are served to the client; Microsoft uses "MVC" as a noun to describe a web service implementation
* Routing - in the context of web services, routing is how requests to a URL are mapped to service methods that generate the response; we say that requests are routed to a handler

# Techs

* .NET Core - open source, portable platform based on the .NET Standard, aims to be container-friendly
* .NET Framework - .NET Standard platform for Windows
* .NET Standard - the standard that defines common functionality between platforms including .NET Framework, .NET Core, and Mono
* ASP.NET - web application framework, shipped with .NET 1.0, successor to Active Server Pages (ASP)
* ASP.NET Core - web application framework based on ASP.NET MVC
* ASP.NET MVC - web application framework based on ASP.NET, introduces an MVC architecture
* ASP.NET Web API - web application framework, similar to ASP.NET MVC
* Internet Information Services (IIS) - web server
* Mono - portable implementation of the .NET Framework
* Open Web Interface for .NET (OWIN) - specification for .NET web apps
* Razor Pages - server rendered web pages for .NET Core
* Xamarin - another name for Mono, but also the name of the Microsoft subsidiary that maintains Mono

# Links

## MS Offical Docs

* [.NET Core Guide](https://docs.microsoft.com/en-us/dotnet/core/)
* [Intro to ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/)
* [Build Web APIs with ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/web-api/)
* [.NET Core vs .NET Framework](https://docs.microsoft.com/en-us/dotnet/standard/choosing-core-framework-server)
* [Migrating from ASP.NET to ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/migration/webapi)
* [Attribute Routing in ASP.NET](https://docs.microsoft.com/en-us/aspnet/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2)

## DotNetPerls

* [Async / Await](https://www.dotnetperls.com/async)
* [OdbcConnection](https://www.dotnetperls.com/odbcconnection)

## Stack Overflow

* [.NET Core vs Mono](https://stackoverflow.com/questions/37738106/net-core-vs-mono)
