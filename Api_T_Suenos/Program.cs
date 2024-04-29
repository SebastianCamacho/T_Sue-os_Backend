using ENTITY;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Extraer connection
var conecctionString = builder.Configuration.GetConnectionString("Connection");
//inyectar servicio de DBContext
builder.Services.AddDbContext<T_Suenos_Context>(options =>
    options.UseSqlServer(conecctionString)
);

var misReglasCors = "ReglasCors";

builder.Services.AddCors(opt =>
opt.AddPolicy(name: misReglasCors, builder =>
{
    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
})
);


builder.Services.AddControllers().AddJsonOptions(opt =>
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); 


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(misReglasCors);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
