using AGDATA.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGDATA.DAL
{
    public static class TempDataList
    {
        public static List<ContactModel> ContactList { get; set; } = new List<ContactModel>();

        public static List<ContactModel> Get()
        {
             return ContactList;
        }

        public static ContactModel? GetById(int id)
        {
             return ContactList.FirstOrDefault(x=> x.Id == id);
        }

        public static void Add(ContactModel contact)
        {
            int maxId = ContactList.OrderByDescending(x => x.Id).First().Id;
            contact.Id = maxId+1;
            ContactList.Add(contact);
        }

        public static void Edit(ContactModel contact)
        {
            var updateContact = ContactList.Find(x => x.Id == contact.Id);
            updateContact.Name = contact.Name;
            updateContact.Address = contact.Address;
        }

        public static void Delete(int id)
        {
            ContactList = ContactList.Where(x => x.Id != id).ToList();
        }
       
    }
}
