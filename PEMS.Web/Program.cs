using Microsoft.EntityFrameworkCore;
using PEMS.Application.Interfaces;
using PEMS.Application.Services;
using PEMS.Persistence.Context;
using PEMS.Persistence.Repositories;

using PEMS.Application.AI.Interfaces;
using PEMS.Application.AI.Search.Interfaces;
using PEMS.Application.AI.Search.Services;
using PEMS.Application.AI.Services;
using PEMS.AI.Interfaces;
using PEMS.AI.Services;

var builder = WebApplication.CreateBuilder(args);


// MVC
builder.Services.AddControllersWithViews();


// Database
builder.Services.AddDbContext<PEMSDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("PEMSConnection")
    ));


// Application Services
builder.Services.AddScoped<IEngineeringDocumentService, EngineeringDocumentService>();


// Persistence Repositories
builder.Services.AddScoped<IEngineeringDocumentRepository, EngineeringDocumentRepository>();

builder.Services.AddScoped<IDocumentAIService, DocumentAIService>();

builder.Services.AddScoped<IDocumentSearchAIService, DocumentSearchAIService>();

builder.Services.AddHttpClient<IOllamaService, OllamaService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:11434/");
});

var app = builder.Build();


// Configure HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);


app.Run();