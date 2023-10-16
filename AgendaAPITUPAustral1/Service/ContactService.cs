using AgendaAPITUPAustral1.Data;
using AgendaAPITUPAustral1.Data.Entities;
using System.Linq;

namespace AgendaAPITUPAustral1.Service
{
    public class ContactService
    {
        private readonly AgendaContext _context;

        public ContactService(AgendaContext context) { _context = context; }

        public List<Contact> GetContacts()
        {
            return _context.Contacts.ToList();
        }
        public Contact? GetContact(int id)
        {
            return _context.Contacts.SingleOrDefault(c => c.Id == id);
        }
        public bool DeleteContact(int id)
        {
            Contact? contactToDelete = GetContact(id);
            if (contactToDelete != null)
            {
                _context.Contacts.Remove(contactToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;

        }
        public Contact UpdateContact(Contact contactToUpdate)
        {
            Contact? updateContact = _context.Update(contactToUpdate).Entity;
            _context.SaveChanges();
            return updateContact;
        }
        public int AddContact(Contact contact)
        {
            int contactId = _context.Contacts.Add(contact).Entity.Id;
            _context.SaveChanges();
            return contactId;
        }
    }
}
