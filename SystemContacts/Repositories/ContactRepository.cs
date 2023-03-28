using SystemContacts.Data;
using SystemContacts.Models;

namespace SystemContacts.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DatabaseContext _databaseContext;
        public ContactRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext; 
        }
        public ContactModel Add(ContactModel entity)
        {
            _databaseContext.Contacts.Add(entity);
            _databaseContext.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            ContactModel? contact = GetById(id);
            if (contact == null) throw new Exception("Delete error");
            _databaseContext.Contacts.Remove(contact);
            _databaseContext.SaveChanges();
            return true;
        }

        public List<ContactModel> GetAll()
        {
            return _databaseContext.Contacts.ToList();
        }

        public ContactModel? GetById(int id)
        {
            return _databaseContext.Contacts.FirstOrDefault(c => c.Id == id);
        }

        public ContactModel Update(ContactModel entity)
        {
            ContactModel? contact = GetById(entity.Id);
            if(contact == null) if (contact == null) throw new Exception($"Update error");
            contact.Name = entity.Name;
            contact.Email = entity.Email;
            contact.Phone = entity.Phone;
            _databaseContext.Contacts.Update(contact);
            _databaseContext.SaveChanges();
            return contact;
        }
    }
}
