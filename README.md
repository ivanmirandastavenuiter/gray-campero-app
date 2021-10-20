## Gray Campero!

<p align="center">
  <img src="https://github.com/ivanmirandastavenuiter/gray-campero-app/blob/main/gc.png" width=500 alt="GC Landing Page" />
</p>

<p align="center">  
  <a href="" target="_blank"><img alt="version" src="https://img.shields.io/badge/version-1.0-brightgreen.svg?style=flat" /></a>
  <a href="" target="_blank"><img alt="owner" src="https://img.shields.io/badge/owner-MKNA--dev-127ab5.svg?style=flat" /></a>
  <a href="https://www.linkedin.com/in/iv%C3%A1n-miranda-stavenuiter-b40412b7/" target="_blank"><img alt="linkedin" src="https://img.shields.io/badge/social-LinkedIn-106494.svg?style=flat" /></a>
  <a href="https://twitter.com/im_stavenuiter" target="_blank"><img alt="twitter" src="https://img.shields.io/twitter/follow/im_stavenuiter.svg?style=social&label=Follow" /></a>
</p>

<p align="center">A web application to celebrate the joy of eating!</p>

## Questions

<p align="justify">First of all, the name!</p>

***How long has it took to build the app?***

<p align="justify">4 days, pretty much. Most of it done during weekend.</p>

***Compile and run solution:***

<p>For front in angular: </p>

1. Install dependencies

```console
npm install
```

2. Run server with ng serve - http://localhost:4200 - Automatic redirection to home

```console
ng serve
```

<p>For back in .NET 3.1: </p>

```console
dotnet run
```

<p>Migrations: </p>

```console
dotnet ef database update
```

***Assumptions***

<p align="justify">A few of them, actually:</p>

* <p>Default users for testing purposes. Login implementation out of scope for this task.</p>

<p align="justify">To make use of them, two initial users have been provided. Ids 1001 and 1002. To manage which one you use in the application, add 'user' parameter in query with value 1001 or 1002. This way, it will fetch one or another.</b></p>

* <p>Implementation and design of database structured in three tables: Users, Products, Cart. Relations among them like:</p>

* Cart - User: many to one - one to many
* Cart - Product: many to one - one to many

***Design***

<p align="justify">I like sober, elegant user interfaces. White backgrounds with not many details and a light-smart choice for colors. Pretty inspired by platforms like Pinterest</p>

## Tooling

* <p>Angular 12</p>
* <p>.NET Core 3.1</p>
* <p>SQL Server 2017</p>

## Packages

<p>For net:</p>

```csharp
  <ItemGroup>
    <PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="8.1.1" />
    <PackageReference Include="Microsoft.AspNetCore.JsonPatch" Version="5.0.11" />
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="5.0.11" />
    <PackageReference Include="Microsoft.AspNetCore.Mvc.NewtonsoftJson" Version="3.1.20" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="5.0.11">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="5.0.11" />
  </ItemGroup>
```

<p>For angular:</p>

* <p>Axios</p>

## Extra tooling

* <p>Unsplash (photographs)</p>
* <p>Font awesome</p>
* <p>Google fonts</p>

## Performance tests

* <p><a href="https://locust.io/">Locust testing platform</a></p>
* <p><a href="https://docs.microsoft.com/es-es/aspnet/core/performance/performance-best-practices?view=aspnetcore-5.0">Recommended practices on ASP NET Core</a></p>

## Versions

## Status for acceptance criteria

* <p>App fully working - All user stories completed</p>
* <p>Performance not tested yet - In progress</p>

## Extra jobs

<p align="justify">I'd like to deploy app with docker, but couldn't because of time</p>

* <p>1.0</p>

## Branches 

* <p>Master</p>
