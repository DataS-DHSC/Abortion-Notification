using FluentValidation;
using DHSC.ANS.API.Consumer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DHSC.ANS.API.Consumer.Validators;

public class HSA4FormValidator : AbstractValidator<HSA4FormDto>
{
	public HSA4FormValidator()
	{
		RuleFor(x => x.Practitioner).SetValidator(new PractitionerInfoValidator());
		RuleFor(x => x.Certification).SetValidator(new CertificationInfoValidator());
		RuleFor(x => x.Patient).SetValidator(new PatientDetailsValidator());
		RuleFor(x => x.Treatment).SetValidator(new TreatmentDetailsValidator());
		RuleFor(x => x.Gestation).SetValidator(new GestationDetailsValidator());
        RuleFor(x => x.TerminationGroundsDto).SetValidator(new TerminationGroundsValidator());
        RuleFor(x => x.ChlamydiaScreening).SetValidator(new ChlamydiaInfoValidator());
		RuleFor(x => x.Complications).SetValidator(new ComplicationsInfoValidator());
		RuleFor(x => x.MaternalDeath).SetValidator(new MaternalDeathInfoValidator());
	}
}
