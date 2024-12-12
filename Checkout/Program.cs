using Checkout.Applicattion.Interface;
using Checkout.Applicattion.Service;
using Checkout.Infrastructure.Interface;
using Checkout.Infrastructure.Persistence;
using Checkout.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure the database context to use SQL Server.
var connectionString = builder.Configuration.GetConnectionString("ConnectionDB");

builder.Services.AddDbContextPool<DataContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//repository
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

//services
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IClienteService, ClienteService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
