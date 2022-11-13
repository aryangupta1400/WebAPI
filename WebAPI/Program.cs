using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Middleware.CustomMiddlewares;
using Model.DBModels;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFluentValidation(s =>
{
    s.RegisterValidatorsFromAssemblyContaining<Program>();
    s.AutomaticValidationEnabled = false;

    /*
        // Validate child properties and root collection elements
        s.ImplicitlyValidateChildProperties = true;
        s.ImplicitlyValidateRootCollectionElements = true;

        // Automatic registration of validators in assembly
        s.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    */
});

builder.Services.AddDbContext<OrganizationContext>(options =>
    options.UseSqlServer("Server=BRD-3917L13-L\\SQLEXPRESS;Database=Organization;Trusted_Connection=True;"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Employee Details API",
        Version = "v1",
        Description = "An API to perform CRUD operations over Employee Details",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Aryan Gupta",
            Url = new Uri("https://twitter.com/agupta"),
        },
        License = new OpenApiLicense
        {
            Name = "Employee API LICX",
            Url = new Uri("https://example.com/license"),
        }
    });
    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseMiddleware<ExceptionHandlingMiddleware>();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
