using AGDATA.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGDATA.Common.Interfaces;

namespace AGDATA.DAL
{
    public class InMemoryDB : IDBContact
    {
        
        public InMemoryDB() {  
            if(TempDataList.ContactList.Count == 0) {
                TempDataList.ContactList.Add (new ContactModel() { Id=1, Name = "Adam", Address = "Vancouver" });
                TempDataList.ContactList.Add (new ContactModel() { Id=2,  Name = "Brian", Address = "Toronto" });
                TempDataList.ContactList.Add (new ContactModel() { Id=3,  Name = "Robert", Address = "Qubec" });
                TempDataList.ContactList.Add (new ContactModel() { Id=4,  Name = "John", Address = "Winterfell" });
                TempDataList.ContactList.Add (new ContactModel() { Id=5,  Name = "Tyvin", Address = "CastallyRock" });
            }
        }

        public List<ContactModel> Get()
        {
             return TempDataList.Get();
        }

        public ContactModel? GetById(int id)
        {
             return TempDataList.GetById(id);
        }

        public void Add(ContactModel contact)
        {
            TempDataList.Add(contact);
        }

        public void Edit(ContactModel contact)
        {
           TempDataList.Edit(contact);
        }

        public void Delete(int id)
        {
            TempDataList.Delete(id);
        }
            
    }
}
