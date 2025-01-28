using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using c_.Domains.DTO;
using c_.Domains.Interfaces;
using c_.Domains.ModelViews;
using c_.Domains.Services;
using c_.Structure.DB;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAdminServices, AdministradorServices>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContexto>( //ligacao do db na API
    options => options.UseMySql(
    builder.Configuration.GetConnectionString("mysql"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
    )
);

var app = builder.Build();

app.MapGet("/", () => Results.Json(new Home()));

app.MapPost("/login", ([FromBody]LoginDTO loginDTO, IAdminServices AdministradorServices) => //leitura da verificacao do login
{
    if (AdministradorServices.Login(loginDTO) != null)
    {
        return Results.Ok("Login com sucesso");
    }else
    {
        return Results.Unauthorized();
    }
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();
