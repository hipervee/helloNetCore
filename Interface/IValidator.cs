using System;

namespace helloApp
{
    public interface IValidator
    {
        ValidatorType Type { get; set; }
        ValidationMessage Validate(FieldMetadata metaData, Field field);
    }
}