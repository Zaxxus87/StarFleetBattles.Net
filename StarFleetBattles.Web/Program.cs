using StarFleetBattles.Application.Services;
using StarFleetBattles.Domain.Services;
using StarFleetBattles.Web.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add logging
builder.Services.AddLogging();

// Register our application services
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IShipMovementService, ShipMovementService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();