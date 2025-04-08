using System.Xml.Linq;
using DHSC.ANS.API.Legacy.Configuration;
using DHSC.ANS.API.Legacy.Interfaces;
using DHSC.ANS.API.Legacy.Services;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AppSettings>(builder.Configuration);
builder.Services.AddSoapCore();
builder.Services.AddSingleton<ISoapMessageService, SoapMessageService>();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<ISoapMessageService>("/Service.svc", new SoapEncoderOptions(), SoapSerializer.DataContractSerializer);
});

app.Run();
