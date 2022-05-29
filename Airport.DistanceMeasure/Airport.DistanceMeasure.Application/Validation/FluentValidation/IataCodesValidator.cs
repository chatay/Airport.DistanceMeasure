using Airport.DistanceMeasure.Application.Constants;
using Airport.DistanceMeasure.Application.DTOs;
using Airport.DistanceMeasure.Application.Extensions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.DistanceMeasure.Application.Validation.FluentValidation
{
    public class IataCodesValidator : AbstractValidator<AirportIataCodesRequest>
    {
        bool toIataCode = true;
        public IataCodesValidator()
        {
            RuleFor(x => x.FromIataCode).IataCodeInput(toIataCode = false);
            RuleFor(x => x.ToIataCode).IataCodeInput(toIataCode = true);
        
            RuleFor(x => new { x.FromIataCode, x.ToIataCode })
                .Must(x => !x.FromIataCode.Equals(x.ToIataCode))
                .WithMessage(ValidationMessages.FromAndDestinyEqualError);
        }
    }
}
