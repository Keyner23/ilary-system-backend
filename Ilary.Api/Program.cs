using Ilary.Application.Interfaces;
using Ilary.Application.Services;
using Ilary.Infrastructure.Persistence;
using Ilary.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


//Services
builder.Services.AddScoped<CoderService>();

//Repositories
builder.Services.AddScoped<ICoderRepository, CoderRepository>();


//  Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//   controllers
builder.Services.AddControllers();

var app = builder.Build();


// Configurar Swagger

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers(); 

app.Run();