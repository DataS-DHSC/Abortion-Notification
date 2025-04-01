using DHSC.ANS.API.Consumer.DependencyInjection;
using DHSC.ANS.API.Consumer.Services;
using DHSC.ANS.API.Consumer.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddHSA4Validators();
builder.Services.AddHSA4FormService();
builder.Services.AddSwaggerDocumentation();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwaggerDocumentation();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
