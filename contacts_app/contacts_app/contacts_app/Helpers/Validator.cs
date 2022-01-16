using contacts_app.Models;
using System.Collections.Generic;

namespace contacts_app.Helpers
{
    public static class Validator
    {
        private const string validationMessage = "Pole {0} nie może być puste.";

        public static string[] ValidateContact(Contact contact)
        {
            var messages = new List<string>();

            if (contact.FirstName == null || contact.FirstName == string.Empty)
            {
                messages.Add(string.Format(validationMessage, "Imię"));
            }

            if (contact.Surname == null || contact.Surname == string.Empty)
            {
                messages.Add(string.Format(validationMessage, "Nazwisko"));
            }

            if (contact.Number == null || contact.Surname == string.Empty)
            {
                messages.Add(string.Format(validationMessage, "Numer"));
            }

            return messages.ToArray();
        }
    }
}
