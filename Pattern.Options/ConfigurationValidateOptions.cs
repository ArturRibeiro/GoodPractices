namespace Pattern.Options
{
    public class ConfigurationValidateOptions<TOptions>: IValidateOptions<TOptions> where TOptions: class
    {
        public ValidateOptionsResult Validate(string name, TOptions options)
        {
            var context = new ValidationContext(options, null, null);
            var errors = new List<ValidationResult>();
            var result = Validator.TryValidateObject(options, context, errors, true);
            if (result) return ValidateOptionsResult.Success;
            var stringResult = errors.Select(validationResult => CreateMessage(validationResult)).ToList();
            return ValidateOptionsResult.Fail(stringResult);
        }

        private static string CreateMessage(ValidationResult validationResult)
        {
            var propertie = $"{string.Join((string?)",", (IEnumerable<string?>)validationResult.MemberNames)}";
            return $"DataAnnotation validation failed for members: '{propertie}' with the error: '{validationResult.ErrorMessage}'.";
        }
    }
}