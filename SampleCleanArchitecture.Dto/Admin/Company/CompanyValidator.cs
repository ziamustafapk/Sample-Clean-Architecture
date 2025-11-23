
namespace SampleCleanArchitecture.Dto.Admin.Company
{
    public class CompanyValidator : AbstractValidator<CompanyForManipulationDto>
    {
        public CompanyValidator()
        {
            RuleFor(c => c.ParentCompanyId)
                .NotEqual(Guid.Empty).WithMessage("Parent Company GUID is not valid.");

            
            RuleFor(c => c.CompanyName)
                .MinimumLength(5)
                .WithMessage("The 'Company Name' should have at least 5 characters.")
                .MaximumLength(250)
                .WithMessage("The 'Company Name' should have not more than 250 characters.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("The 'Email' is not in not valid.")
                .EmailAddress().WithMessage("The 'Email' is not in not valid.")
                .MaximumLength(50)
                .WithMessage("The 'Email' should have not more than 250 characters.");
            RuleFor(c => c.Phone)
                .NotEmpty().WithMessage("The 'Phone' Number is not valid.")
                .MinimumLength(11)
                .WithMessage("The 'Phone' should have at least 11 characters.")
                .MaximumLength(11)
                .WithMessage("The 'Phone' should have not more than 11 characters.");

        }

        protected override bool PreValidate(ValidationContext<CompanyForManipulationDto> context, ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));
                return false;
            }
            return true;
        }
    }
}
