using contacts_app.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace contacts_app.Services
{
    internal interface IContactTableService
    {
        Task<List<Contact>> GetContacts();

        Task<int> AddContact(Contact contact);

        Task<int> EditContact(Contact contact);
        
        Task<int> RemoveContact(Contact contact);
    }
}
