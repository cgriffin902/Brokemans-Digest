using BrokeMans.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokeMans.Data
{
    public class BrokeContext : IdentityDbContext<ApplicationUser>
    {
        public BrokeContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public static BrokeContext Create()
        {
            return new BrokeContext();
        }

    }

}
