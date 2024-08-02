using AGDATA.Common.Interfaces;
using AGDATA.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace AGDATA.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactInformationController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactInformationController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet(Name = "GetContacts")]
        public IEnumerable<ContactModel> Get()
        {
            return _contactService.GetAllContacts();
        }

        [HttpPost(Name = "AddContact")]
        public void Get([FromBody] ContactModel contact)
        {
            _contactService.CreateContacts(contact);
        }

        [HttpPatch(Name = "UpdateContact")]
        public void Patch([FromBody] ContactModel contact)
        {
            _contactService.EditContacts(contact);
        }

        [HttpDelete(Name = "DeleteContact/{id:int}")]
        public void Delete(int id)
        {
            _contactService.DeleteContacts(Convert.ToInt32(id));
        }
    }
}
