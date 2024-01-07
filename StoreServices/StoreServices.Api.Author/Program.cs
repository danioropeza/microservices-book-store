using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Author.Application;
using StoreServices.Api.Author.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(configuration => 
    configuration.RegisterValidatorsFromAssemblyContaining<New>()
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AuthorContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseConnection"));
});
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(New.Execute).Assembly);
});
builder.Services.AddAutoMapper(typeof(Query.Handler).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
