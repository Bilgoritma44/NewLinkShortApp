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
        public DbSet<Company> Companies { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<NewCertificate> NewCertificates { get; set; }
        public DbSet<FieldValue> FieldValues { get; set; }

    }
}