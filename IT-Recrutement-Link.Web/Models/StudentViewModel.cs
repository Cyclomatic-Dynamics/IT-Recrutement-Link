using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using IT_Recrutement_Link.Domain.Domain;
namespace IT_Recrutement_Link.Web.Models
{
    public class StudentViewModel
    {
        
        [Required]
        [EmailAddress]
        [Display(Name="E-mail Address")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [CompareAttribute("Password", ErrorMessage="Password and Confirmation Does Not Match" )]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm the Password")]
        public string PasswordConfirm { get; set; }
        
        [Required]
        [MaxLength(50)]
        [RegularExpression("[^0-9]+", ErrorMessage="Your Name Must Not Contain Numbers")]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        [RegularExpression("[^0-9]+", ErrorMessage = "Your LastName Must Not Contain Numbers")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string University { get; set; }
        public DateTime BeginDate { get; set; }
        public string Honors { get; set; }
    }
}