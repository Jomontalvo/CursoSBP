using CursoSBP.Api.Security;
using CursoSBP.Data;
using CursoSBP.Data.Interfaces;
using CursoSBP.Data.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string cnx = builder.Configuration.GetConnectionString("ConeccionCurso")!;
builder.Services.AddDbContext<DataContext>(o =>
    o.UseSqlServer(cnx, sql => sql.UseNetTopologySuite()));
builder.Services.AddScoped<IStudentsService, StudentsService>();

builder.Services.AddAuthentication("BasicAuthenticationHandler")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthenticationHandler", null);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
