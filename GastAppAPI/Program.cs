using GastAppAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("http://localhost:3000",
                         "http://192.168.0.29:3000",
                         "https://misfinanzasapp.vercel.app",
                         "https://misfinanzasapp.com/")  // Reemplaza con tu URL de frontend
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));

// Configure logging
builder.Logging.ClearProviders(); // Limpia los proveedores de logging por defecto
builder.Logging.AddConsole(); // Agrega logging a la consola

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Apply CORS policy
app.UseCors("AllowSpecificOrigin");  // Asegúrate de que esté aquí

// Apply security headers
app.Use(async (context, next) =>
{   
    context.Response.Headers.Add("Cross-Origin-Opener-Policy", "same-origin");
    context.Response.Headers.Add("Cross-Origin-Embedder-Policy", "require-corp");
    await next();
});

app.UseHttpsRedirection();
app.UseStaticFiles();  // Si usas archivos estáticos
app.UseRouting();
app.UseAuthentication();  // Si usas autenticación
app.UseAuthorization();
app.MapControllers();  // O cualquier otro endpoint
app.Run();
