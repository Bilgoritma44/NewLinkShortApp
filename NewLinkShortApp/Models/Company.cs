using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewLinkShortApp.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<Template> Templates { get; set; }
        public ICollection<AppUser> AppUsers { get; set; }


    }
}