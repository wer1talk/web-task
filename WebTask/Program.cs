using Microsoft.EntityFrameworkCore;
using WebTask.Data;

var builder = WebApplication.CreateBuilder(args);
// Добавляем CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Указываем URL вашего Angular фронтенда
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");



builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));
    


builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("AllowAngularApp");
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();