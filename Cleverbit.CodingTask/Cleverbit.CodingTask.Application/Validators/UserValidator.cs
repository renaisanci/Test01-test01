using Cleverbit.CodingTask.Application.Requests;
using FluentValidation;

namespace Cleverbit.CodingTask.Application.Validators
{

    public class UserValidator : AbstractValidator<UserAuthRequest> {
        public UserValidator() {
            RuleFor(a => a.UserName).NotEmpty().MaximumLength(100);
            RuleFor(a => a.Password).NotEmpty().MaximumLength(100);
        }
    }
}
