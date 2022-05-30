using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewLinkShortApp.Models
{
    public class NewCertificate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string Code { get; set; }
        public int TemplateId { get; set; }
        public Template Template { get; set; }


    }
}