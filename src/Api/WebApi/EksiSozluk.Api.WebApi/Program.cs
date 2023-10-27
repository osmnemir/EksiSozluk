//using EksiSozluk.Api.Application.Extensions;
//using EksiSozluk.Api.Infrastructure.Persistence.Extensions;
//using EksiSozluk.Api.WebApi.Infrastructure.ActionFilters;
//using EksiSozluk.Api.WebApi.Infrastructure.Extensions;
//using EksiSozluk.AspNetCore;
using EksiSozluk.Infrastructure.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureRegistration(builder.Configuration);
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
