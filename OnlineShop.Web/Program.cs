using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using OnlineShop.Core;
using OnlineShop.Infrastructure;
using OnlineShop.Infrastructure.Data;
using OnlineShop.Service;
using OnlineShop.Service.Mapping;

MapperConfiguration mapperConfiguration = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
AutoMapperConfiguration.Initialize(mapperConfiguration);

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<OnlineShopDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineShopWebContext") ?? throw new InvalidOperationException("Connection string 'OnlineShopWebContext' not found.")));
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration["RedisCacheUrl"];
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddCoreServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddAppServices(builder.Configuration);
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<OnlineShopDbContext>()
            .AddDefaultTokenProviders();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Description = "Online Shop Version 1.0 API",
        Title = "V1",
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = String.Empty;
});
await OnlineShopDbContext.SeedUsersAndRolesAsync(app);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
