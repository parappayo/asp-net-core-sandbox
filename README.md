
# asp-net-core-sandbox

A minimal ASP.NET Core web API demo for experimenting. Various learning resources are collected here.

# Concepts

* Attribute Routing - uses C# attributes to denote request handlers; the alternative in ASP.NET is convention-based routing
* Managed Runtime Environment - platform that runs virtual machine code rather than native code, memory management is handled by the VM; .NET is an example of this
* Model-View-Controller (MVC) - a common software design pattern; under .NET Core, controllers are the implementations of service end-points, models are data sources for the controllers, and views are the web pages that are served to the client; Microsoft uses "MVC" as a noun to describe a web service implementation
* Routing - in the context of web services, routing is how requests to a URL are mapped to service methods that generate the response; we say that requests are routed to a handler

# Techs

* .NET Core - open source, portable platform based on the .NET Standard
* .NET Framework - .NET Standard platform for Windows
* .NET Standard - the standard that defines common functionality between platforms including .NET Framework, .NET Core, and Mono
* ASP.NET - web application framework, shipped with .NET 1.0, successor to Active Server Pages (ASP)
* ASP.NET Core - web application framework based on ASP.NET MVC
* ASP.NET MVC - web application framework based on ASP.NET, introduces an MVC architecture
* ASP.NET Web API - web application framework, similar to ASP.NET MVC
* Internet Information Services (IIS) - web server
* Mono - portable implementation of the .NET Framework
* Razor Pages - server rendered web pages for .NET Core
* Xamarin - another name for Mono, but also the name of the Microsoft subsidiary that maintains Mono

# Links

## MS Offical Docs

* [.NET Core Guide](https://docs.microsoft.com/en-us/dotnet/core/)
* [Intro to ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/)
* [Build Web APIs with ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/web-api/)
* [.NET Core vs .NET Framework](https://docs.microsoft.com/en-us/dotnet/standard/choosing-core-framework-server)
* [Migrating from ASP.NET to ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/migration/webapi)

## DotNetPerls

* [Async / Await](https://www.dotnetperls.com/async)
* [OdbcConnection](https://www.dotnetperls.com/odbcconnection)

## Stack Overflow

* [.NET Core vs Mono](https://stackoverflow.com/questions/37738106/net-core-vs-mono)
