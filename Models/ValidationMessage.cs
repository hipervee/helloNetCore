using System;

namespace helloApp
{
    public class ValidationMessage
    {
        public ValidationMessage()
        {
            IsValid = true;
        }
        public ValidationMessage(bool isValid)
        {
            IsValid = isValid;
        }

        public ValidationMessage(bool isValid, string message)
        {
            IsValid = isValid;
            Message = message;
        }
        public bool IsValid { get; set; }
        public string Message { get; set; }
    }
}