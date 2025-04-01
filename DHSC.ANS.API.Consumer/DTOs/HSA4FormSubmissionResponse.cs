using DHSC.ANS.API.Consumer.Models;

namespace DHSC.ANS.API.Consumer.DTOs;

public class Hsa4FormSubmissionResponse : Resource
{
    public string Id { get; set; }
    public string Message { get; set; }

    public HSA4Form? FormData { get; set; }
}