using ECommerceApp.Application;
using ECommerceApp.Application.Validators.Products;
using ECommerceApp.Infrastructure;
using ECommerceApp.Infrastructure.Enums;
using ECommerceApp.Infrastructure.Filters;
using ECommerceApp.Persistence;
using FluentValidation.AspNetCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services?.AddControllers(opt => opt.Filters.Add<ValidationFilter>()).
                 AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>()).
                 ConfigureApiBehaviorOptions(opt => opt.SuppressModelStateInvalidFilter = true);

builder.Services.AddStorage(StorageType.Local);
builder.Services.AddApplicationService();
builder.Services.AddPersistenceServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication("Admin").AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidateAudience = true,

        ValidIssuer = builder.Configuration["Token:Issuer"],
        ValidAudience = builder.Configuration["Token:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])) 

    };

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
