using Microsoft.EntityFrameworkCore;
using ProgrammingWithPalermo.ChurchBulletin.Core.Queries;
using ProgrammingWithPalermo.ChurchBulletin.DataAccess;
using ProgrammingWithPalermo.ChurchBulletin.DataAccess.Handlers;
using ProgrammingWithPalermo.ChurchBulletin.DataAccess.Mappings;
using UI;
using UI.Client.Pages;
using UI.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddHttpClient();

// Configure default HttpClient options
builder.Services.ConfigureHttpClientDefaults(options =>
{
    options.ConfigureHttpClient(client =>
    {
        var baseAddress = builder.Configuration["BaseAddress"] ??
                         "https://localhost:7228/";
        client.BaseAddress = new Uri(baseAddress);
    });
});

builder.Services.AddControllers();

builder.Services.AddTransient<IChurchBulletinItemByDateHandler, ChurchBulletinItemByDateHandler>();
builder.Services.AddScoped<DbContext, DataContext>();
builder.Services.AddDbContextFactory<DataContext>();
builder.Services.AddDbContextFactory<DbContext>();
builder.Services.AddTransient<IDataConfiguration, DataConfiguration>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(UI.Client._Imports).Assembly);

app.MapControllers();

app.Run();
