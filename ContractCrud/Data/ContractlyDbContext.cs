using ContractCrud.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ContractCrud.Data
{
    public class ContractlyDbContext : DbContext
    {
        public ContractlyDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
