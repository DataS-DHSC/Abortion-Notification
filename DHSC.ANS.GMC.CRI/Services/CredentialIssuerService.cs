using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using DHSC.ANS.GMC.CRI.Models;

namespace DHSC.ANS.GMC.CRI.Services;

public class CredentialIssuerService
{
    private readonly ECDsa _ecdsa;
    private readonly string _issuer;

    public CredentialIssuerService(IConfiguration config)
    {
        _issuer = config["CredentialIssuer:Did"] ?? "did:web:cri.ans.dhsc.gov.uk";
        _ecdsa = ECDsa.Create();
        _ecdsa.ImportFromPem(File.ReadAllText("Keys/ec_private.pem"));
    }

    public string Issue(CredentialSubject subject)
    {
        var payload = new JwtPayload
        {
            { "@context", "https://www.w3.org/2018/credentials/v1" },
            { "type", new[] { "VerifiableCredential" } },
            { "issuer", _issuer },
            { "issuanceDate", DateTime.UtcNow.ToString("o") },
            {
                "credentialSubject", new Dictionary<string, object>
                {
                    { "id", subject.Id },
                    { "name", subject.Name },
                    { "gmcNumber", subject.GmcNumber },
                    { "registrationStatus", subject.RegistrationStatus },
                    { "profession", subject.Profession },
                    { "qualification", subject.Qualification },
                    { "registrationDate", subject.RegistrationDate },
                    { "gender", subject.Gender }
                }
            }
        };

        var header = new JwtHeader(new SigningCredentials(
            new ECDsaSecurityKey(_ecdsa),
            SecurityAlgorithms.EcdsaSha256));

        var token = new JwtSecurityToken(header, payload);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
