using BlazorWebAppMovies.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BlazorWebAppMoviesContext") ?? throw new InvalidOperationException("Connection string 'BlazorWebAppMoviesContext' not found.");

builder.Services.AddDbContextFactory<BlazorWebAppMoviesContext>(options => options.UseSqlite(connectionString));

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // Configures exception handler middleware that processes errors and displays a custom page
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // HTTP strict transport security protocol (HSTS)
    // The default HSTS value is 30 days. 
    // You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    // to read more about HSTS
    app.UseHsts();
    app.UseMigrationsEndPoint();
}
// for unhandled 400 - 599, re-executes request pipeline and redirects to not found page
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
// routes http request to https port if available
app.UseHttpsRedirection();
// enables anti forgery protection for form processing
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
