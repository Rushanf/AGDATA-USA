using AGDATA.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGDATA.Common.Interfaces
{
    public interface IDBContact
    {
        List<ContactModel> Get();

        ContactModel? GetById(int id);

        void Add(ContactModel contact);

         void Edit(ContactModel contact);

        void Delete(int id);
    }
}
