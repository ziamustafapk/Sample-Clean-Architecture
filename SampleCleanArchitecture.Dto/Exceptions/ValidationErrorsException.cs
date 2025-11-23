namespace SampleCleanArchitecture.Dto.Exceptions
{
    public class ValidationErrorsException : Exception
    {
        public List<string> ValidationErrors { get; set; } = new();
        public Dictionary<string, string> ValidationErrorsWithName { get; set; } = new();

        public ValidationErrorsException(ValidationResult validationResult)
        {
            ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

            ValidationErrorsWithName = validationResult
                .Errors
                .GroupBy(e => ToCamelCase(e.PropertyName))
                .ToDictionary(
                    g => g.Key,
                    g => string.Join(" ", g.Select(e => e.ErrorMessage))
                );
        }
        public static string ToCamelCase(string value)
        {
            return string.IsNullOrEmpty(value)
                ? value
                : char.ToLowerInvariant(value[0]) + value.Substring(1);
        }
    }


}
