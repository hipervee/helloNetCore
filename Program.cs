using System;
using System.Collections.Generic;
using System.Linq;

namespace helloApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var validationManager = new ValidationManager(GetMetadata());


            var fields = new List<Field>() {
                new Field("/name", "Name", ""),
                new Field("/name", "Name", ""),
                new Field("/name", "Name", null),
                new Field("/email", "Email", "Yahoo"),
                new Field("/email", "Email", null),
            };
            validationManager.InitializeDataFields(fields);
            var validationMessage = validationManager.Validate();
            validationMessage.ValidationMessages.ForEach(o => Console.WriteLine(o.Message));
            Console.Read();
        }

        static List<FieldMetadata> GetMetadata()
        {
            var metaData = new List<FieldMetadata>()
            {
                new FieldMetadata("Name", "/name", new List<string>() {"Required"}),
                new FieldMetadata("Email", "/email", new List<string>() {"Email"})
            };
            return metaData;
        }
    }
}
