using EfWithWebAPI;
using EfWithWebAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//CORS Policy
builder.Services.AddCors(setupAction =>
{
    setupAction.AddPolicy("defualt", policy =>
    {
        policy
        .AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod();

        //policy.WithOrigins("http://127.0.0.1:5500")
        //.WithMethods("GET", "PUT")
        //.WithHeaders();
    });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(configuration =>
{
    configuration.UseSqlServer(builder.Configuration.GetConnectionString("mssql"));
});
builder.Services.AddScoped(typeof(ProductRepository));
builder.Services.AddScoped(typeof(CategoryRepository));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("defualt");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
