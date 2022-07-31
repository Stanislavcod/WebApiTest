using Microsoft.EntityFrameworkCore;
using UserCompany.Model.DataBaseContext;
using AutoMapper;
using UserCompany.Model;
using UserCompany.Model.Models;
using UserCompany.BusinessLogic.Mapper;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.

builder.Services.AddDbContext<ApplicationDataBaseContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Initialize the mapper
var mappinpConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
IMapper mapper = mappinpConfig.CreateMapper();




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
