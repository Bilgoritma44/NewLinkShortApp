using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewLinkShortApp.Models
{
    public class FieldValue
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string Value { get; set; }
        public int TemplateId { get; set; }
        public Template Template { get; set; }


    }
}