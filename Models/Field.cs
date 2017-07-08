using System;
using System.Collections.Generic;
using System.Linq;

namespace helloApp
{
    public class FieldMetadata
    {
        public FieldMetadata(string name, string path, List<string> attributes)
        {
            Name = name;
            Path = path;
            Attributes = attributes.Select(o => new FieldAttribute(o, "")).ToList();
            Validators = new List<IValidator>();
            DataFields = new List<Field>();
        }
        public string Name { get; set; }
        public string Path { get; set; }
        public List<FieldAttribute> Attributes { get; set; }
        public List<Field> DataFields { get; set; }
        public List<IValidator> Validators { get; set; }
    }
    public class Field
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Path { get; set; }
        public ValidationMessage ValidationMessage { get; set; }

        public Field(string path, string name, string value)
        {
            Path = path;
            Name = name;
            Value = value;
        }

        public bool IsValid
        {
            get
            {
                return ValidationMessage.IsValid;
            }
        }
    }

    public class FieldAttribute
    {
        public FieldAttribute(string name, string value)
        {
            Name = name;
            Value = value;
        }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}