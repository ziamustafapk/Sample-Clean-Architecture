namespace SampleCleanArchitecture.Dto.Application.Customer
{
    public class CustomerForManipulationValidator : AbstractValidator<CustomerForManipulationDto>
    {
        public CustomerForManipulationValidator()
        {
            
            RuleFor(c => c.Title)
                .NotEmpty()
                .Length(2, 50).WithMessage("The 'Title' should be between 3 to 50 character.");
            RuleFor(c => c.FirstName)
                .NotEmpty()
                .Length(3, 50).WithMessage("The 'First Name' should be between 3 to 50 character.");
            RuleFor(c => c.LastName)
                .NotEmpty()
                .Length(3, 50).WithMessage("The 'Last Name' should be between 3 to 50 character.");
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress()
                .Length(3, 150).WithMessage("The 'Email' should be between 3 to 150 character.");
            RuleFor(c => c.Phone)
                .NotEmpty()
                .Length(11, 14).WithMessage("The 'Phone' should be between 11 to 11 character.");
            RuleFor(c => c.Company)
                .NotEmpty()
                .Length(3, 150).WithMessage("The 'Company' should be between 3 to 150 character.");
        }

        protected override bool PreValidate(ValidationContext<CustomerForManipulationDto> context, ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("Customer Creation Dto", "Please ensure a model was supplied."));
                return false;
            }
            return true;
        }
    }

    
}
