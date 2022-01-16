using contacts_app.Models;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace contacts_app.Services
{
    public class ContactTableService : IContactTableService
    {
        private readonly IConnectionHandlerService _connectionHandlerService;

        public ContactTableService()
        {
            _connectionHandlerService = FreshIOC.Container.Resolve<IConnectionHandlerService>();

            _connectionHandlerService.AsyncConnection.CreateTableAsync<Contact>().Wait();
        }

        public Task<int> AddContact(Contact contact)
        {
            if(contact.Id == Guid.Empty)
            {
                contact.Id = Guid.NewGuid();
            }

            return _connectionHandlerService.AsyncConnection.InsertAsync(contact);
        }

        public Task<int> EditContact(Contact contact)
        {
            return _connectionHandlerService.AsyncConnection.UpdateAsync(contact);
        }

        public Task<List<Contact>> GetContacts()
        {
            return _connectionHandlerService.AsyncConnection.Table<Contact>().ToListAsync();
        }

        public Task<int> RemoveContact(Contact contact)
        {
            return _connectionHandlerService.AsyncConnection.DeleteAsync(contact);
        }
    }
}
