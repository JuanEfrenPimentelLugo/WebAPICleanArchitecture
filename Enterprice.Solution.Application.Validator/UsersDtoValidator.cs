using System;
using FluentValidation;
using Enterprice.Solution.Application.DTO;

namespace Enterprice.Solution.Application.Validator
{
    public class UsersDtoValidator : AbstractValidator<UserDto>
    {
        public UsersDtoValidator()
        {
            RuleFor(u => u.UserName).NotNull().NotEmpty();
            RuleFor(u => u.Password).NotNull().NotEmpty();
        }
    }
}
