using Microsoft.AspNetCore.Mvc;
using DHSC.ANS.GMC.CRI.Services;

namespace DHSC.ANS.GMC.CRI.Controllers;

[ApiController]
[Route("api/credential")]
public class CredentialIssuerController : ControllerBase
{
    private readonly GmcLookupService _gmc;
    private readonly CredentialIssuerService _issuer;

    public CredentialIssuerController(GmcLookupService gmc, CredentialIssuerService issuer)
    {
        _gmc = gmc;
        _issuer = issuer;
    }

    [HttpGet("{gmcNumber}")]
    public async Task<IActionResult> Get(string gmcNumber)
    {
        var subject = await _gmc.LookupAsync(gmcNumber);
        if (subject is null) return NotFound("Doctor not found or not licensed.");

        var jwt = _issuer.Issue(subject);
        return Ok(new { vcJwt = jwt });
    }
}
