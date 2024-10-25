using Microsoft.EntityFrameworkCore;
using ApiEmpresa.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

String? cadena = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddControllers();
if(cadena!=null){
builder.Services.AddDbContext<Conexiones>(opt =>
    /*opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); Esto es para SQL SERVER*/
    opt.UseMySQL(cadena));
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
