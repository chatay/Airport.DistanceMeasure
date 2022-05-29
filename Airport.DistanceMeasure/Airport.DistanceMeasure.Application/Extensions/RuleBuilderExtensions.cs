using Airport.DistanceMeasure.Application.Constants;
using Airport.DistanceMeasure.Application.Validation.RegexValidator;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.DistanceMeasure.Application.Extensions
{
    public static class RuleBuilderExtensions
    {
        public static IRuleBuilder<T, string> IataCodeInput<T>(this IRuleBuilder<T, string> ruleBuilder, bool toIataCode)
        {
            var options = ruleBuilder
                .NotEmpty().WithMessage(ValidationMessages.IataCodeIsEmpty)
                .Must(IataCodeValidator.IsValid).WithMessage(toIataCode ? ValidationMessages.DestinyIataCodeNotValid : ValidationMessages.FromIataCodeNotValid)
                .MinimumLength(3).WithMessage(ValidationMessages.IataCodeLengthNotValid)
                .MaximumLength(3).WithMessage(ValidationMessages.IataCodeLengthNotValid);

            return options;
        }
    }
}
