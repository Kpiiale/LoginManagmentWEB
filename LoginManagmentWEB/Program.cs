using LoginManagmentWEB.Components;
using LoginManagmentWEB.Services;
using LoginManagmentWEB.Services.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage; 


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped(sp =>
{
    var handler = new HttpClientHandler();

    if (builder.Environment.IsDevelopment())
    {
        handler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => true;
    }

    return new HttpClient(handler, disposeHandler: false)
    {
        BaseAddress = new Uri("https://localhost:7162")
    };
});

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, JWTAuthStateProvider>();
builder.Services.AddScoped<JWTAuthStateProvider>();
builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddScoped<UserService>(); 
builder.Services.AddAuthorizationCore();
builder.Services.AddTransient<AuthHeaderHandler>();

builder.Services.AddHttpClient<UserService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7162/");
}).AddHttpMessageHandler<AuthHeaderHandler>();
builder.Services.AddTransient<AuthHeaderHandler>();
builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7162/"); 
}).AddHttpMessageHandler<AuthHeaderHandler>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();
