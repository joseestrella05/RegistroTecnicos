using Microsoft.EntityFrameworkCore;
using RegistrosTecnico.Components;
using RegistrosTecnico.DAL;
using RegistrosTecnico.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var ConStr = builder.Configuration.GetConnectionString("ConStr");

builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlServer(ConStr));

builder.Services.AddBlazorBootstrap();

//Inyeccci�n del service
builder.Services.AddScoped<TecnicoService>();
builder.Services.AddScoped<ClientesServices>();
builder.Services.AddScoped<CiudadeServices>();
builder.Services.AddScoped<TicketsServices>();
builder.Services.AddScoped<SistemaServices>();
builder.Services.AddScoped<DeudoresService>();
builder.Services.AddScoped<PrestamosService>();
builder.Services.AddScoped<CobrosServices>();
builder.Services.AddScoped<PrestamosDetalleService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
