using Microsoft.EntityFrameworkCore;
using SystemContacts.Models;

namespace SystemContacts.Data
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {}

        public DbSet<ContactModel> Contacts { get; set; }
    }
}
