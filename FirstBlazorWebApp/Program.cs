using FirstBlazorWebApp.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

app.UseHttpsRedirection();

app.UseAntiforgery(); // Middleware para proteger contra ataques CSRF (Cross-Site Request Forgery)

app.MapStaticAssets(); // Rastreia os arquivos estáticos da pasta wwwroot

// Mapeando os componentes da nossa aplicação e adicionando interatividade através do server
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();