using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewLinkShortApp.Models
{
    public class Link
    {
        public int Id { get; set; }
        
        [RegularExpression(@"(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)")]
        public string LongUrl { get; set; }
        public string Code { get; set; }
        public string ShortUrl { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}