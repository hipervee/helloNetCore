using System;
using System.Collections.Generic;
using System.Linq;

namespace helloApp
{
    public class FileValidationMessage
    {
        public FileValidationMessage()
        {
            ValidationMessages = new List<ValidationMessage>();
        }
        public bool IsValid
        {
            get
            {
                return !ValidationMessages.Any(o => !o.IsValid);
            }
        }
        public List<ValidationMessage> ValidationMessages { get; set; }

        public void AddMessage(ValidationMessage message)
        {
            ValidationMessages.Add(message);
        }
    }
}