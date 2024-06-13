using Microsoft.EntityFrameworkCore;
using WebTest.Data.Context;
using WEBTest.DataExetion;
using WebTest.Data.Repositories;
using WEBTest.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NasosDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services
//    .AddMeltData(AppSettings.Instance.ConnectionString)
//    .AddServices();
builder.Services.AddScoped<NasosService>();
builder.Services.AddScoped<NasosRepository>();
builder.Services.AddScoped<MotorService>();
builder.Services.AddScoped<MotorRepository>();
builder.Services.AddScoped<MaterialService>();
builder.Services.AddScoped<MaterialRepository>();


var app = builder.Build();


app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MigrateDatabase();

app.UseCors(options => 
{
    options.AllowAnyHeader();
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
});

app.Run();
