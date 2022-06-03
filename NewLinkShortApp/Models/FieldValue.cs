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
        public string  Value { get; set; }
        public string  Text_ { get; set; }
        public string  Text_1 { get; set; }
        public string  Text_2 { get; set; }
        public string  Text_3 { get; set; }
        public string  Text_4 { get; set; }
        public string  Text_5 { get; set; }
        public int TemplateId { get; set; }
        public Template Template { get; set; }


    }
}