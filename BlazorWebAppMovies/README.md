# BlazorWebAppMovies

## Setup

- This project was created using visual studio code, using C# dev kit and using the **.NET: New project** for Blazor web app template
- Add Nuget packages and tools (one time setup)

```shell
dotnet tool install --global Microsoft.dotnet-scaffold

# one time setup to make dotnet tools like 
# dotnet-ef (for entity framework) and dotnet-scaffold (across the os)
cat << \EOF >> ~/.zprofile
# Add .NET Core SDK tools
export PATH="$PATH:/Users/gauravsingh/.dotnet/tools"
EOF

# after that run below to make it available in current session
zsh -l
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
