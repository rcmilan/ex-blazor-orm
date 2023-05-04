using BlazorORM.App.Data.Configuration;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("ORMDB"));

builder.Services.AddScoped(serviceProvider =>
 {
     return new HttpClient
     {
         BaseAddress = new Uri(serviceProvider.GetRequiredService<NavigationManager>().BaseUri)
     };
 });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();