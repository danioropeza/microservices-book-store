using Microsoft.EntityFrameworkCore;
using StoreServices.Api.ShoppingCart.Application;
using StoreServices.Api.ShoppingCart.Persistence;
using StoreServices.Api.ShoppingCart.RemoteInterfaces;
using StoreServices.Api.ShoppingCart.RemoteServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IBooksService, BooksService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*builder.Services.AddControllers().AddFluentValidation(configuration =>
    configuration.RegisterValidatorsFromAssemblyContaining<New>()
);*/
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ShoppingCartContext>(options =>
{
    var serverVersion = new MySqlServerVersion(new Version(8, 0, 34));
    options.UseMySql(builder.Configuration.GetConnectionString("DatabaseConnection"), serverVersion);
    //options.UseMySQL(builder.Configuration.GetConnectionString("DatabaseConnection"));
});
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(New.Execute).Assembly);
});
//builder.Services.AddAutoMapper(typeof(Query.Handler).Assembly);
builder.Services.AddHttpClient("Books", configuration =>
{
    configuration.BaseAddress = new Uri(builder.Configuration["Services:Books"]);
});

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
