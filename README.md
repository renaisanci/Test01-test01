

# Cleverbit Coding Task - Overview

# Client (front-end)

- [React](https://reactjs.org/docs/getting-started.html)
- [React Context API](https://reactjs.org/docs/context.html)
- [Privite Route](https://reactjs.org/docs/context.html)
- [dotEnv](https://www.npmjs.com/package/dotenv)
 

# Service (back-end)

- [ASP.NET Core 3.1](https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/intro)
- [Unit Of Work](https://martinfowler.com/eaaCatalog/unitOfWork.html)
- [EF COR](https://docs.microsoft.com/en-us/ef/core/)
- [Repository](https://martinfowler.com/eaaCatalog/repository.html)
- [DRY]( Don't repeat yourself )
- [DDD]( https://martinfowler.com/tags/domain%20driven%20design.html) 
- [Basic authentication](https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/basic-authentication) 
- [Swagger UI](https://github.com/swagger-api/swagger-ui)

# How to run locally

1. [Download and install the .NET Core SDK](https://dotnet.microsoft.com/download)
    * If you don't have `localdb` available on your system, [Download and install SQL Server Express](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)
```sh
dotnet build
dotnet run --project Microsoft.DSX.ProjectTemplate.API
```
3. Open your browser to: `https://localhost:44345/swagger`.
4. In another terminal, navigate to the `client` folder and run the following `npm` commands:
```sh
npm install
npm start
```
5. The front-end and your browser will open to: `http://localhost:3000`

# To-Do back-end

1. DotNet Dynamic Injector would be good
2. Include Authorization logic
3. Get Current Matches
4. Get All Matches

# To-Do front-end

1. Submit Play
2. Get Current Matches
3. List All matches


 

