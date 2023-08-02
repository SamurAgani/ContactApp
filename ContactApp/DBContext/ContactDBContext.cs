using ContactApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.DBContext
{
    public class ContactDBContext : DbContext
    {

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
        public ContactDBContext(DbContextOptions<ContactDBContext> options) : base(options)
        {}
    }
}
