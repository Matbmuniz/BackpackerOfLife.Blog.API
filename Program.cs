using BackpackerOfLife.Blog.API.AppServices;
using BackpackerOfLife.Blog.API.AppServices.IAppServices;
using BackpackerOfLife.Blog.API.Context;
using BackpackerOfLife.Blog.API.Services;
using BackpackerOfLife.Blog.API.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BlogDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DevelopmentConnection"), sqlOpt => sqlOpt.EnableRetryOnFailure())); //MainConnection


builder.Services.AddScoped<IMainAppService, MainAppService>();
builder.Services.AddScoped<IMainService, MainService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var scope = app.Services.CreateScope();
var DbContext = scope.ServiceProvider.GetRequiredService<BlogDbContext>();
DbContext.Database.EnsureCreated();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
