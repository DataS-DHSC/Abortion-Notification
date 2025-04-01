using DHSC.ANS.API.Consumer.DTOs;
using FluentValidation;

namespace DHSC.ANS.API.Consumer.Validators;

public class PractitionerInfoValidator : AbstractValidator<PractitionerInfo>
{
	public PractitionerInfoValidator()
	{
		RuleFor(x => x.FullName).NotEmpty();
		RuleFor(x => x.Address).NotEmpty();
		RuleFor(x => x.GmcNumber).Matches(@"^\d{7}$");
		RuleFor(x => x.DateOfSignature).NotEmpty();
	}
}
