﻿using FluentValidation;
using Enterprice.Solution.Application.DTO;

namespace Enterprice.Solution.Application.Validator
{
    public class DiscountDtoValidator: AbstractValidator<DiscountDto>
    {
        public DiscountDtoValidator() {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Description).NotNull().NotEmpty();
            RuleFor(x => x.Percent).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
