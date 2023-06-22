# Tutorials

Getting started: 
https://www.youtube.com/watch?v=OgdpC35qHc0

Full:
- https://www.youtube.com/playlist?list=PLM5JAv_WpgH_FKWlsGkbiKUczG4BU8mv5
- https://www.youtube.com/playlist?list=PL6n9fhu94yhVm6S8I2xd6nYz2ZORd7X2v
- https://www.youtube.com/watch?v=E7Voso411Vs
- API https://www.youtube.com/playlist?list=PL6n9fhu94yhW7yoUOGNOfHurUE6bpOO2b

# Setup

![](https://raw.githubusercontent.com/atabegruslan/TravellersNet/master/Illustrations/Create%20NET%20core%20or%20NET%20project%201.png)

![](https://raw.githubusercontent.com/atabegruslan/TravellersNet/master/Illustrations/Create%20NET%20core%20or%20NET%20project%202.png)

- Have .NET Framework 4.x.x installed first: https://www.microsoft.com/en-us/download/details.aspx?id=30653
- Visual Studio 2019 version https://visualstudio.microsoft.com/downloads/
  - Better usage: https://www.youtube.com/watch?v=ifTF3ags0XI
- Install VS features

![](https://raw.githubusercontent.com/atabegruslan/TravellersNet/master/Illustrations/Download%20VS%20features.png)

## Databases

If you don't have MsSQL server installed, you can still use the local DB server:

![](https://raw.githubusercontent.com/atabegruslan/TravellersNet/master/Illustrations/localDB.png)

Here's how to have MsSQL server and MsSQL server management studio: 
- https://www.guru99.com/download-install-sql-server.html
- https://www.youtube.com/watch?v=VfEI7A0i8J4&list=WL&index=1

# ORM

In this project EF is used for ORM

![](https://raw.githubusercontent.com/atabegruslan/TravellersNet/master/Illustrations/EF.PNG)

- An example of DB first: https://www.entityframeworktutorial.net/entityframework6/create-entity-data-model.aspx
- An example of linking Code and DB without using the wizard: https://github.com/Ruslan-Aliyev/AspNet_MVC_EF
- https://www.youtube.com/watch?v=qkJ9keBmQWo

## Various ORMs

- As of 2020, the ORM "in-fashion" is the **Entity Framework**. 
- **Linq** is more like Repository and Unit Of Work patterns.
- **ADO.NET** is the traditional method to help access DB with C#. It's like a middleware library. It have 2 kinds: 
  - Use Query method,
  - Use dataadapter, Dataset, to bind datatable with Database.

More refs:
- https://www.dotnettricks.com/learn/entityframework/difference-between-linq-to-sql-and-entity-framework
- https://stackoverflow.com/questions/3293995/what-is-the-difference-between-entity-framework-and-linq-to-sql-by-net-4-0
- https://www.dotnettricks.com/learn/linq/difference-between-adonet-and-linq-to-sql
- https://www.c-sharpcorner.com/interview-question/difference-between-adonet-and-entity-framework
- https://www.geeksforgeeks.org/difference-between-ado-and-ado-net/
- https://www.quora.com/Which-ORM-framework-is-best-for-NET
- https://stackoverflow.com/questions/657220/which-is-the-best-data-access-framework-approach-for-c-sharp-and-net

# User Accounts, Login: 

- Simplest Example: https://www.c-sharpcorner.com/article/simple-login-application-using-Asp-Net-mvc/

# Publish

![](https://raw.githubusercontent.com/atabegruslan/TravellersNet/master/Illustrations/publish.png)

# Opening existing projects

Open the `.sln` file

# API

1. Top bar -> Tools -> Nuget Package Manager -> Package Manager Console: `PM> Install-Package Microsoft.AspNet.WebApi`

2. Add to `Global.asax`:

```
...
using System.Web.Http; // <- ADD

public class MvcApplication : System.Web.HttpApplication
{
    protected void Application_Start()
    {
        ...
        GlobalConfiguration.Configure(WebApiConfig.Register); // <- ADD
        ...
```

3. `App_Start/WebApiConfig.cs`

```
public static class WebApiConfig
{
    public static void Register(HttpConfiguration config)
    {
        config.MapHttpAttributeRoutes();

        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
    }
}
```

4. Create a new API controller:

Right click controllers folder -> add -> controller -> Web API 2 Controller

```
[RoutePrefix("Api/Destinations")]
public class RestApiController : ApiController
{
    [HttpGet]
    [Route("Test")]
    public string Test()
    {
        return "Welcome To Web API blah blah";
    }
```

5. Visit `https://localhost:{port}/Api/Destinations/Test`

- https://stackoverflow.com/questions/11990036/how-to-add-web-api-to-an-existing-asp-net-mvc-4-web-application-project
- https://www.c-sharpcorner.com/article/create-simple-web-api-in-asp-net-mvc/
- https://www.codingvila.com/2021/05/angular-12-crud-example-with-web-api.html?m=1

# More Tutorials

.NET core: 
- https://www.youtube.com/playlist?list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU
- https://www.youtube.com/watch?v=79UWvR734wI
- https://www.youtube.com/watch?v=Dpv6lUKNL9o
  - https://www.youtube.com/watch?v=4a9VxZjnT7E

ASP.NET core: 
- https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-3.1&tabs=visual-studio
- https://www.youtube.com/watch?v=1ck9LIBxO14
- https://www.youtube.com/playlist?list=PL2Q8rFbm-4ruplp2SRUTQjZaFfxh-knS0

AJAX:
- https://stackoverflow.com/questions/15687903/ajax-web-api-post-method-how-does-it-work
