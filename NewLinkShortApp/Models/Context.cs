using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewLinkShortApp.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOPSN-PF22HQ\\DENEME;database=IndataShortLink;integrated security=true");
        }
        public DbSet<Link> Links { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

    }
}