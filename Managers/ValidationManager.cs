using System;
using System.Collections.Generic;
using System.Linq;

namespace helloApp
{
    public class ValidationManager
    {
        public ValidationManager(List<FieldMetadata> metadata)
        {
            Validators = new List<IValidator>() {
                new RequiredFieldValidator(),
                new EmailValidator()
            };
            Metadata = metadata;
            AssociateValidatorsToFields();
        }

        List<IValidator> Validators { get; set; }
        List<FieldMetadata> Metadata { get; set; }

        void AssociateValidatorsToFields()
        {
            Metadata.ForEach(o =>
            {
                AssociateValdatorsToField(o);
            });
        }

        void AssociateValdatorsToField(FieldMetadata metadata)
        {
            metadata.Attributes.ForEach(o =>
            {
                var validator = GetValidatorForAttribute(o);
                if (validator != null)
                {
                    metadata.Validators.Add(validator);
                }
            });
        }

        IValidator GetValidatorForAttribute(FieldAttribute attribute)
        {
            ValidatorType type;
            if (Enum.TryParse<ValidatorType>(attribute.Name, out type))
            {
                return Validators.FirstOrDefault(o => o.Type == type);
            }
            return null;
        }
        public void InitializeDataFields(List<Field> dataFields)
        {
            Metadata.ForEach(o =>
            {
                o.DataFields = dataFields.Where(m => m.Path == o.Path).ToList();
            });
        }

        public FileValidationMessage Validate()
        {
            FileValidationMessage fileValidationMessage = new FileValidationMessage();

            Metadata.ForEach(m =>
            {
                m.Validators.ForEach(v =>
                {
                    var dataFieldIndex = 0;
                    m.DataFields.ForEach(d =>
                    {
                        d.ValidationMessage = v.Validate(m, d);
                        if (!d.ValidationMessage.IsValid)
                        {
                            var message = string.Format("[FieldIndex:{0}] - {1}", dataFieldIndex, d.ValidationMessage.Message);
                            fileValidationMessage.AddMessage(new ValidationMessage(false, message));
                        }

                        dataFieldIndex++;
                    });
                });
            });

            return fileValidationMessage;
        }
    }
}