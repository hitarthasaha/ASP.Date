using Microsoft.EntityFrameworkCore;
using API.Data;
using API;
using API.Extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddCors();
builder.Services.AddScoped<ITokenService, TokenService>();
var app = builder.Build();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200","https://localhost:4200"));
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
