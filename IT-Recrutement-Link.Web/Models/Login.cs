using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IT_Recrutement_Link.Web.Models
{
    public class Login
    {
        [Required]
        [Display(Name = "Email")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        public Choice ChosenChoice
        {
            get;
            set;
        }
        
        public enum Choice
        {
            
            Student = 0,
            Company = 1
            
        }

        
    }
}