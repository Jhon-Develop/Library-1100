using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using DotNetEnv; // Importar el paquete DotNetEnv
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using library_1100.Controllers;
using library_1100.Database;

var builder = WebApplication.CreateBuilder(args);

// Cargar las variables del archivo .env
DotNetEnv.Env.Load();

// Construir la cadena de conexión usando las variables del entorno
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
string port = Environment.GetEnvironmentVariable("DB_PORT");
string server = Environment.GetEnvironmentVariable("DB_SERVER");
string database = Environment.GetEnvironmentVariable("DB_DATABASE");
string user = Environment.GetEnvironmentVariable("DB_USER");
string password = Environment.GetEnvironmentVariable("DB_PASSWORD");
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL

string connectionString = $"Server={server};Database={database};User Id={user};Password={password};";

// Conectar a la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21))));

// Register the IDataService and its implementation
builder.Services.AddScoped<IDataService, DataService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
