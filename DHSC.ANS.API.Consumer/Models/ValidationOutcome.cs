namespace DHSC.ANS.API.Consumer.Models;

public class ValidationOutcome
{
    public bool IsValid { get; set; }
    public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
}
