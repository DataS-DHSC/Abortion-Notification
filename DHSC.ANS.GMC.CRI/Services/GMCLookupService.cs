using HtmlAgilityPack;
using DHSC.ANS.GMC.CRI.Models;

namespace DHSC.ANS.GMC.CRI.Services;

public class GmcLookupService
{
    private readonly HttpClient _http;

    public GmcLookupService(HttpClient http) => _http = http;

    public async Task<CredentialSubject?> LookupAsync(string gmcNumber)
    {
        var res = await _http.GetAsync($"https://www.gmc-uk.org/registrants/{gmcNumber}");
        if (!res.IsSuccessStatusCode) return null;

        var html = await res.Content.ReadAsStringAsync();
        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        var name = doc.DocumentNode.SelectSingleNode("//h1[@id='registrantNameId']")?.InnerText?.Trim();
        var status = doc.DocumentNode.SelectSingleNode("//div[@class='c-rg-details__status-description']//div")?.InnerText?.Trim();

        if (string.IsNullOrEmpty(name) || !status?.Contains("licence to practise", StringComparison.OrdinalIgnoreCase) == true)
            return null;

        var qualification = doc.DocumentNode.SelectSingleNode("//div[contains(@class,'c-rg-details__pmq')]/div")?.InnerText?.Trim();
        var regDate = doc.DocumentNode.SelectSingleNode("//div[contains(text(),'Full registration date')]/following-sibling::div")?.InnerText?.Trim();
        var gender = doc.DocumentNode.SelectSingleNode("//div[contains(text(),'Gender')]/following-sibling::div")?.InnerText?.Trim();

        return new CredentialSubject
        {
            Id = $"did:web:cri.ans.dhsc.gov.uk:{gmcNumber}",
            Name = name,
            GmcNumber = gmcNumber,
            RegistrationStatus = status,
            Profession = "Doctor",
            Qualification = qualification ?? "",
            RegistrationDate = regDate ?? "",
            Gender = gender ?? ""
        };
    }
}
