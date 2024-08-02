using AGDATA.Common.Interfaces;
using AGDATA.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AGDATA.BL.Service
{
    public class ContactService : IContactService
    {
        IDBContact _dBContact;
        public ContactService(IDBContact dBContact)
        {            
            _dBContact = dBContact;
        }
        
        public void AddNewContact(string Name, string Address)
        {
            _dBContact.Add (new ContactModel() { Name = Name, Address = Address });
        }

        public List<ContactModel> GetAllContacts()
        {
            return _dBContact.Get();
        }

        public ContactModel? GetContactById(int id)
        {
            return _dBContact.GetById(id);
        }

        public void CreateContacts(ContactModel contact)
        {
            _dBContact.Add(contact);
        }

        public void EditContacts(ContactModel contact)
        {
            _dBContact.Edit(contact);
        }

        public void DeleteContacts(int id) 
        {
            _dBContact.Delete(id);
        }
    }
}
