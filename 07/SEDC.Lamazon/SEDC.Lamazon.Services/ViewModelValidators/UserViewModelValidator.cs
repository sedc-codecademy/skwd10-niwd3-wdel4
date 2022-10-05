using FluentValidation;
using SEDC.Lamazon.Domain.Constants;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels.Models;

namespace SEDC.Lamazon.Services.ViewModelValidators
{
    public class UserViewModelValidator: AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator(IUsersService usersService)
        {
            RuleFor(x => x).Must(x => usersService.HasOtherAdmins(x)).When(x => x.RoleKey != Roles.Admin).WithName(x => nameof(x.RoleKey)).WithMessage("There must be at least one admin on the platform.");
        }
    }
}
