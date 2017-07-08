using System;

namespace helloApp
{
    public class EmailValidator : IValidator
    {
        public EmailValidator()
        {
            Type = ValidatorType.Email;
        }
        public ValidatorType Type { get; set; }
        public ValidationMessage Validate(FieldMetadata metaData, Field field)
        {
            if (field.Value != "Yahoo")
            {
                var message = string.Format("Domain is not Valid");
                return new ValidationMessage(false, message);
            }
            return new ValidationMessage();
        }
    }
}