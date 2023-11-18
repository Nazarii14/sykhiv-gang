using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DAL.Data
{
    public class MilitaryProjectContext : DbContext
    {
        public MilitaryProjectContext() : base()
        {

        }
        public MilitaryProjectContext(DbContextOptions<MilitaryProjectContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql("Host=berry.db.elephantsql.com;Username=hahsvkpo;Password=lMEv9WvZDXhC3rRBgmFv5qN8yXmQl2Fn;Database=hahsvkpo;");
        }
        
    }
}
