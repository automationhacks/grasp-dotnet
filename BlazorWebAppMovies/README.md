# BlazorWebAppMovies

Read [Build a Blazor movie database](https://learn.microsoft.com/en-us/aspnet/core/blazor/tutorials/movie-database-app/?view=aspnetcore-10.0) to understand how to work with Blazor web framework, entity framework (EF) and databases

## Setup

- This project was created using visual studio code, using C# dev kit and using the **.NET: New project** for Blazor web app template
- Add Nuget packages and tools (one time setup)

```shell
dotnet tool install --global Microsoft.dotnet-scaffold
dotnet tool install --global dotnet-ef

# (Optional) set dotnet version at project level
dotnet new globaljson --sdk-version 10.0.202 --force
# these tools are installed in /Users/<your_user_name>/.dotnet/tools

# one time setup to make dotnet tools like 
# dotnet-ef (for entity framework) and dotnet-scaffold (across the os)
cat << \EOF >> ~/.zprofile
# Add .NET Core SDK tools
export PATH="$PATH:/Users/gauravsingh/.dotnet/tools"
EOF

# after that run below to make it available in current session
zsh -l
```

```shell
# Optional: If EF Core Design package is not present
dotnet add package Microsoft.EntityFrameworkCore.Design --version 10.0.7
```

## Run

- To run, select Program.cs and press F5, select C# and `BlazorWebAppMovies [Default configuration]` option
- Alternatively, you could also run `dotnet watch` command

> If you need to run the app on a different port, you can change it in BlazorWebAppMovies/Properties/launchSettings.json

## Project structure

Read about this [here](https://learn.microsoft.com/en-us/aspnet/core/blazor/tutorials/movie-database-app/part-1?view=aspnetcore-10.0&pivots=vsc#examine-the-project-files)

- `Properties` has development env config in `launchSettings.json`
- `wwwroot` has static assets like `.js` and `.css`
- `Components`: a component is self contained piece of UI with optional processing logic
  - They can be **nested**, **reused** and **shared** among projects. They are combination of **HTML** and **C# markup** in `.razor` files
  - `Pages`: components that are routable via a URL are placed under `Pages`
  - `Layout`: contains different layout component and stylesheets
    - `MainLayout`: app's main layout component and its css
    - `NavMenu`: component to render navigation links
    - `ReconnectModal`: reflects server side connection state in the UI
  - `/Components/_Imports.razor`: uses `@` to include razor directives (C# imports) for components
  - `/Components/App.razor`: root component of the app that has HTML markup, `Routes` Component, Scripts. This is the first component that loads
  - `/Components/Routes.razor`: set up routing on the app
- `/appsettings.json`: config settings

> Use [Secret Manager tool](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-10.0&tabs=windows) for **local development testing** and securing sensitive data. It would store secrets (any sensitive data) in a JSON file in users profile directory and convenient helper methods can be used to access them in app. Also, learn about **authN (authentication) and authZ (authorization) via managed identities** for production apps

- `Program.cs`: code to create the app and configure request processing pipeline of the app

## Dotnet scaffold and Entity framework migrations

- We use dotnet scaffold, it is a code generation framework that quickly adds database context from models and UI code that interacts with data model. Follow selections guidance from [here](https://learn.microsoft.com/en-us/aspnet/core/blazor/tutorials/movie-database-app/part-2?view=aspnetcore-10.0&pivots=vsc#scaffold-the-model) that helps to wire a Blazor component using SQLite as the local db context and produces a CRUD app with required EF (Entity framework) mappings

```shell
dotnet scaffold
```

EF (entity framework) is an ORM (Object relational mapper) that takes a code first approach. EF core tooling takes care of database upgrades, migrations and aims to speed up development.

- Entity classes are created and updated in app
- The db is created and updated from the apps entity classes

```shell
# Install dotnet EF
dotnet tool install --global dotnet-ef

# Update dotnet ef tool
dotnet tool update --global dotnet-ef

# Run migration
dotnet tool run dotnet-ef migrations add InitialCreate

dotnet ef database update
```

`migrations` generates the code to create initial db schema. Here `InitialCreate` is the name of the migration

After the Migrations is created, you can update the db using `update` command. It executes `Up` method in migrations that haven't been applied yet

## Working with Database (DB)

- Tutorial can be found [Build a Blazor movie database app (Part 4 - Work with a database)](https://learn.microsoft.com/en-us/aspnet/core/blazor/tutorials/movie-database-app/part-4?view=aspnetcore-10.0&pivots=vsc)
- We can add data annotations to the model class to add validations on the database schema. In general, we should keep the model and the database schema in sync

```shell
# Create migration after making a change in the model
dotnet ef migrations add NewMovieDataAnnotations
# Update the database with the migrations
dotnet ef database update
```

## Resources

- You should understand how to setup AuthN and AuthZ for Blazor apps. Read [this](https://learn.microsoft.com/en-us/aspnet/core/blazor/security/?view=aspnetcore-10.0) for an overview and how to secure your app using [OIDC (OpenID connect)](https://learn.microsoft.com/en-us/aspnet/core/blazor/security/blazor-web-app-with-oidc?view=aspnetcore-10.0) or [Microsoft Entra ID](https://learn.microsoft.com/en-us/aspnet/core/blazor/security/blazor-web-app-with-entra?view=aspnetcore-10.0)
- For Microsoft Azure services, you can read how to use [managed identities for Azure SQL](https://learn.microsoft.com/en-us/azure/azure-sql/database/authentication-azure-ad-user-assigned-managed-identity) and for [App service and Azure functions](https://learn.microsoft.com/en-us/azure/app-service/overview-managed-identity)
