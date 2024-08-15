using ContractCrud.Data;
using ContractCrud.Models;
using ContractCrud.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContractCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly ContractlyDbContext dbContext;

        public ContractController(ContractlyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult GetAllContacts()
        {
           var Contacts= dbContext.Contacts.ToList();
            return Ok(Contacts);
        }

        [HttpPost]
        public IActionResult AddContacts(AddContractDTO addContractDTO)
        {
            var domainaddcontact = new Contact
            { 
                Id= Guid.NewGuid(),
                Name = addContractDTO.Name,
                Email = addContractDTO.Email,
                Phone = addContractDTO.Phone,
                Favorite= addContractDTO.Favorite,
            };
            dbContext.Contacts.Add(domainaddcontact);
            dbContext.SaveChanges(); 
            return Ok(domainaddcontact);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteContacts(Guid id)
        {
            var contacts=dbContext.Contacts.Find(id);
            if(contacts is not null)
            {
                dbContext.Contacts.Remove(contacts);
                dbContext.SaveChanges();
            }
            return Ok(); 

        }

    }
}
