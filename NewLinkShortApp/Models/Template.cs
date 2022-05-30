using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewLinkShortApp.Models
{
    public class Template
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string FilePath { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<FieldValue> FieldValues { get; set; }
        public ICollection<NewCertificate> NewCertificates { get; set; }


    }
}