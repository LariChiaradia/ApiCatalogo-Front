using CategoriasMvc.Services;
using CategoriasMVC.Services;
using CategoriasMVC.Services.Interfaces;
using Microsoft.AspNetCore.DataProtection;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient("CategoriasApi", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ServiceUri:CategoriasApi"]);
});
builder.Services.AddHttpClient("ProdutosApi", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ServiceUri:ProdutosApi"]);
});
builder.Services.AddHttpClient("AutenticaApi", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ServiceUri:AutenticaApi"]);
    c.DefaultRequestHeaders.Accept.Clear();
    c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.Cookie.SameSite = SameSiteMode.None;
//    options.Cookie.SecurePolicy = CookieSecurePolicy.None;
//});

builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IAutenticacao, Autenticacao>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
