# BlazorWebAppMovies

## Setup

- This project was created using visual studio code, using C# dev kit and using the .NET: New project for Blazor web app template

## Run

- To run, select Program.cs and press F5, select C# and `BlazorWebAppMovies [Default configuration]` option
- Alternatively, you could also run `dotnet watch` command

> If you need to run the app on a different port, you can change it in BlazorWebAppMovies/Properties/launchSettings.json

## Project structure

- `Properties` has development env config in `launchSettings.json`
- `wwwroot` has static assets like `.js` and `.css`
- `Components`: a component is self contained piece of UI with optional processing logic, they can be nested, reused and shared among projects. They are combination of HTML and C# markup in `.razor`
  - `Pages`: components that are routable via a URL are placed under `Pages`
  - `Layout`: contains different layout component and stylesheets
