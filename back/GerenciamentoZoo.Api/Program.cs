using GerenciamentoZoo.Api.ExceptionFilter;
using GerenciamentoZoo.Application.Animais;
using GerenciamentoZoo.Application.Cuidados;
using GerenciamentoZoo.Contrato.Animais;
using GerenciamentoZoo.Contrato.Cuidados;
using GerenciamentoZoo.Infra.Animais;
using GerenciamentoZoo.Infra.Cuidados;
using GerenciamentoZoo.Infra.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IAnimaisRepository, AnimaisRepository>();
builder.Services.AddScoped<IAnimaisUseCase, AnimaisUseCase>();
builder.Services.AddScoped<ICuidadosRepository, CuidadosRepository>();
builder.Services.AddScoped<ICuidadosUseCase, CuidadosUseCase>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()  
              .AllowAnyHeader()  
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
