using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Web.Models
{
    public class LoginModel
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }    
    }
}
