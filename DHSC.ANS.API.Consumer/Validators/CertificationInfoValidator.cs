using DHSC.ANS.API.Consumer.DTOs;
using FluentValidation;

namespace DHSC.ANS.API.Consumer.Validators;

public class CertificationInfoValidator : AbstractValidator<CertificationInfoDto>
{
	public CertificationInfoValidator()
	{
		RuleFor(x => x.CertifyingDoctor1Name).NotEmpty();
		RuleFor(x => x.CertifyingDoctor1Address).NotEmpty();
		RuleFor(x => x.CertifyingDoctor2Name).NotEmpty();
		RuleFor(x => x.CertifyingDoctor2Address).NotEmpty();
	}
}
