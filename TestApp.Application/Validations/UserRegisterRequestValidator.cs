
using FluentValidation;
using TestApp.Application.DTOs.Requests;

namespace TestApp.Application.Validations
{
    public class UserRegisterRequestValidator : AbstractValidator<UserRegisterRequest>
    {
        public UserRegisterRequestValidator()
        {
            RuleFor(userDetailsRequest => userDetailsRequest.Password).NotEmpty().MaximumLength(60).Matches(@"(?=.*[a-z].*)(?=.*[A-Z].*)(?=.*\d.*)");
            RuleFor(userDetailsRequest => userDetailsRequest.Email).NotEmpty().EmailAddress().MaximumLength(60);
        }
    }
}
