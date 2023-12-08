using API_Avaliacao.Application.Mappings;
using API_Avaliacao.Domain.Interfaces;
using API_Avaliacao.Infraestructure.Data;
using API_Avaliacao.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

////
builder.Services.AddDbContext<ConnectionDbContext>();

//configuração de injeção de dependencia (AddSingleton, AddScoped, AddTransiente)
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<IServidorRepository, ServidorRepository>();

builder.Services.AddAutoMapper(typeof(EntitiesToDtoMappingProfile));
//

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
