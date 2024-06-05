using Api.Microservice.Autor.Aplicacion;
using Api.Microservice.Autor.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Strategy.Aplicacion;
using Strategy.Concretas;
using Strategy.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAgregarAutor, AgregarAutorConcreta>();
builder.Services.AddScoped<IConsultarAutor, ConsultarAutorConcreta>();
builder.Services.AddScoped<IConsultarF, ConsultarFiltroConcreta>(); // Agregar esta l�nea
builder.Services.AddScoped<ValidacionesEjecuta>(); // Agregar esta l�nea

builder.Services.AddDbContext<ContextoAutor>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

builder.Services.AddMediatR(typeof(Nuevo.Manejador).Assembly);
builder.Services.AddAutoMapper(typeof(Consulta.Manejador));

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
