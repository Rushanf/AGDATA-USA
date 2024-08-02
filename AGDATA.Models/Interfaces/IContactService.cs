using AGDATA.Common.Models;

namespace AGDATA.Common.Interfaces
{
    public interface IContactService
    {
        public void AddNewContact(String Name, String Address);
        public List<ContactModel> GetAllContacts();
        public void CreateContacts(ContactModel contact);
        public ContactModel? GetContactById(int id);
        public void EditContacts(ContactModel contact);
        public void DeleteContacts(int id) ;

    }
}
