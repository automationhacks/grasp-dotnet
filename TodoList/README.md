# TodoList app

## Setup

```shell
# Here -o <ProjectName> creates a scaffolding blazor project
dotnet new blazor -o TodoList
```

## Development

To add a new razor component

```shell
# -n or --name is name of component
# -o or --output is the directory where component should be present
dotnet new razorcomponent -n Todo -o Components/Pages
```

To run the app

```shell
# This would launch the web app in local, it also supports hot
# reloading, wherein certain changes can be easily seen immidiately
dotnet watch
```
