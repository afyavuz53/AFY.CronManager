using AFY.CronManager.HangfireApi.Extensions;
using AFY.CronManager.Infrastructure.Extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Host.AddConfiguration();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddHangfireConfiguration(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseAuthorization();

app.MapControllers();

app.UseMyHangfireApplication();
HangfireExtension.AddMyJob();

app.Run();
