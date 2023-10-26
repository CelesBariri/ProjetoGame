using Microsoft.EntityFrameworkCore;
using ProjetoGame.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/*builder.Services.AddDbContext<Contexto> //Rafael
    (options => options.UseSqlServer("Data Source=SB-1490645\\SQLSENAI;Initial Catalog = ProjetoGame;Integrated Security = True;TrustServerCertificate = True"));*/

/*builder.Services.AddDbContext<Contexto> //Felipe
    (options => options.UseSqlServer("Data Source=SB-1490632\\SQLSENAI;Initial Catalog = ProjetoGame;Integrated Security = True;TrustServerCertificate = True"));*/

/*builder.Services.AddDbContext<Contexto> //Gabriel
    (options => options.UseSqlServer("Data Source=SB-1490657\\SQLSENAI;Initial Catalog = ProjetoGame;Integrated Security = True;TrustServerCertificate = True"));*/

/*builder.Services.AddDbContext<Contexto> //Vinicius
    (options => options.UseSqlServer("Data Source=SB-1490631\\SQLSENAI;Initial Catalog = ProjetoGame;Integrated Security = True;TrustServerCertificate = True"));*/

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
