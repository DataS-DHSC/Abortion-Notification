using DHSC.ANS.API.Consumer.DTOs;
using DHSC.ANS.API.Consumer.Enums;
using FluentValidation;

namespace DHSC.ANS.API.Consumer.Validators;

public class TreatmentDetailsValidator : AbstractValidator<TreatmentDetails>
{
	public TreatmentDetailsValidator()
	{
		RuleFor(x => x.AdministrationSetting).IsInEnum();
		RuleFor(x => x.Funding).IsInEnum();
		RuleFor(x => x.ServiceProviderOrganisation)
			.NotEmpty().When(x => x.AdministrationSetting == AdministrationSetting.AllAtHome);
		RuleFor(x => x.PlaceOfTerminationName)
			.NotEmpty().When(x => x.AdministrationSetting != AdministrationSetting.AllAtHome);
	}
}
