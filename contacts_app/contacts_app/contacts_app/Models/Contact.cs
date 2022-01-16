using SQLite;
using System;

namespace contacts_app.Models
{
    public class Contact
    {
        [PrimaryKey]
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        
        public string Surname { get; set; }

        public string Number { get; set; }
    }
}
