using FluentValidation;
using IdentityProject.DtoLayer.Dtos.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProject.BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
			RuleFor(x => x.Name).MinimumLength(2).WithMessage("Name must be at least 2 characters");
			RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Surname cannot be empty");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email cannot be empty");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email format is not correct");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username cannot be empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Confirm password cannot be empty");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Passwords do not match");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email format is not correct");
        }
    }
}
