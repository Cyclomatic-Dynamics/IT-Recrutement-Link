﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_Recrutement_Link.Domain.Domain
{
    [Table("Students")] 
    public class Student : User
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public List<Diploma> Diplomas { get; set; }
        [Required]
        public List<Experience> Experiences { get; set; }
        public string PictureUrl { get; set; }
        public string VideoUrl { get; set; }
    }
}
