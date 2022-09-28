using ECommerceServices.Catalog.AppSettings;
using ECommerceServices.Catalog.Mapping;
using ECommerceServices.Catalog.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;
using System;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DBSettings"));
builder.Services.AddSingleton<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new AuthorizeFilter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration.GetSection("IdentityServerURL").Value;
    options.Audience = "ResourceCatalog";
    options.RequireHttpsMetadata = false;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
