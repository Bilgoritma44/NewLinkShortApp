using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewLinkShortApp.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        [Column(TypeName = "Varchar(30)")]
        [StringLength(30, ErrorMessage = "Girdiğiniz Değer 30 Karekateri Geçemez.")]
        public string Name { get; set; }
        [Column(TypeName = "Varchar(20)")]
        [StringLength(20, ErrorMessage = "Girdiğiniz Değer 20 Karekateri Geçemez.")]
        public string Surname { get; set; }
        //[Column(TypeName = "Varchar")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Geçersiz E-mail Adresi")]
        public string Email { get; set; }

        //[Column(TypeName = "Varchar")]
        [StringLength(int.MaxValue, MinimumLength = 8, ErrorMessage = "Parola 8 Karakter'den Az olamaz.")]
        public string Password { get; set; }
        public string Role { get; set; }
        public ICollection<Link> Links { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}