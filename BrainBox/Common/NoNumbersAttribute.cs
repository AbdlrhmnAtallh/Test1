using System.ComponentModel.DataAnnotations;

namespace BrainBox.Common
{
        public class NoNumbersAttribute : ValidationAttribute
        {
            protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    //if (Regex.IsMatch((string)value, @"/d"))
                    var name = value.ToString();
                    if (name.Any(char.IsDigit))
                    {
                        return new ValidationResult("Name should not contain numbers.");
                    }
                }
                return ValidationResult.Success;
            }
        }
}
