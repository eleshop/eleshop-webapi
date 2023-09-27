using Eleshop.WebApi.Configurations.Layers;
using Eleshop.WebApi.Configurations;
using Microsoft.AspNetCore.Diagnostics;
using Eleshop.WebApi.Meddlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();
builder.ConfigureJwtAuth();
builder.ConfigureSwaggerAuth();
builder.ConfigureCORSPolicy();
builder.ConfigureDataAccess();
builder.ConfigureServiceLayer();
builder.ConfigureWeb();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseStaticFiles();
//app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseMiddleware<CrossOriginAccessMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();