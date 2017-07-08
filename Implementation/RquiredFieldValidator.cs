using System;

namespace helloApp
{
    public class RequiredFieldValidator : IValidator
    {
        public RequiredFieldValidator()
        {
            Type = ValidatorType.Required;
        }
        public ValidatorType Type { get; set; }
        public ValidationMessage Validate(FieldMetadata metaData, Field field)
        {
            if (string.IsNullOrEmpty(field.Value))
            {
                var message = string.Format("Field {0} cannot be empty", metaData.Name);
                return new ValidationMessage(false, message);
            }
            return new ValidationMessage();
        }
    }
}