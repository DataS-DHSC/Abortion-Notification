using DHSC.ANS.GMC.CRI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<GmcLookupService>();
builder.Services.AddSingleton<CredentialIssuerService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
