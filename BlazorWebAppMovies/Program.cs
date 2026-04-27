using BlazorWebAppMovies.Components;

var builder = WebApplication.CreateBuilder(args);

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
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
