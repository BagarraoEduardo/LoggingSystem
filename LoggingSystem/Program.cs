using LoggingSystem.Business;
using LoggingSystem.Business.Interfaces;
using Serilog.Events;
using Serilog;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

//builder.Host.UseSerilog(new LoggerConfiguration()
//       .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
//       .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
//       .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Warning)
//       .ReadFrom.Configuration(builder.Configuration)
//       .CreateLogger());

using (SqlConnection conn = new SqlConnection("Data Source=EDUARDOFILI83E3\\SQLEXPRESS;Initial Catalog=LogggingSystem; TrustServerCertificate=true; MultipleActiveResultSets=true; User Id=LoggingSystem; Password=LoggingSystem; Encrypt=false;")) 
{
    conn.Open(); // throws if invalid
}

//var configSettings = new ConfigurationBuilder()
//        .AddJsonFile("appsettings.json")
//        .Build();

//Log.Logger = new LoggerConfiguration()
//    .ReadFrom
//    .Configuration(configSettings)
//    .CreateLogger();

//builder
//    .Host
//    .ConfigureAppConfiguration((builderContext, config) => config.AddConfiguration(configSettings))
//    .ConfigureLogging(logging => logging.AddSerilog());

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMainService, MainService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
