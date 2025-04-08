using System;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Storage.Queues;
using Microsoft.Extensions.Options;
using DHSC.ANS.API.Legacy.Configuration;
using DHSC.ANS.API.Legacy.Interfaces;
using DHSC.ANS.API.Legacy.Models;

namespace DHSC.ANS.API.Legacy.Services
{
    public class SoapMessageService : ISoapMessageService
    {
        private readonly AppSettings.StorageQueueConfig _queueSettings;

        public SoapMessageService(IOptions<AppSettings> options)
        {
            _queueSettings = options.Value.StorageQueue;
        }

        public async Task<ProcessNewCaseFormResponse> ProcessNewCaseForm(CaseFormRequest caseFormRequest)
        {
            var submissionId = Guid.NewGuid().ToString();
            var formId = $"S{DateTime.UtcNow:yyMM}-{Random.Shared.Next(1000, 9999)}";
            var submittedAt = DateTime.UtcNow;

            var xmlString = System.Net.WebUtility.HtmlDecode(caseFormRequest.CaseFormControl);
            var xml = XElement.Parse(xmlString).ToString(SaveOptions.DisableFormatting);

            var envelope = new LegacySubmissionEnvelope
            {
                SubmissionId = submissionId,
                FormId = formId,
                SubmittedAt = submittedAt,
                RawXml = xml
            };

            var queueClient = new QueueClient(_queueSettings.ConnectionString, _queueSettings.QueueName);
            await queueClient.CreateIfNotExistsAsync();

            if (await queueClient.ExistsAsync())
            {
                var encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(System.Text.Json.JsonSerializer.Serialize(envelope)));
                await queueClient.SendMessageAsync(encoded);
            }

            return new ProcessNewCaseFormResponse
            {
                Result = new ProcessNewCaseFormResult
                {
                    Control = new Control
                    {
                        GUID = submissionId,
                        FormID = formId
                    }
                }
            };
        }
    }
}
