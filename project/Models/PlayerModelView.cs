using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic.CompilerServices;

namespace project.Models
{
    public class PlayerModelView
    {
        [Required]
        public int PlayerId { get; set; }
        
        [Required]
        [Display(Name = "Имя")]
        [DataType(DataType.Text)]
        [MinLength(3)]
        [MaxLength(15)]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Фамилия")]
        [DataType(DataType.Text)]
        [MinLength(3)]
        [MaxLength(15)]
        public string Surname { get; set; }
        
        [Display(Name = "Пол")]
        [Required]
        public string Sex { get; set; }
        
        [Display(Name = "Дата рождения")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        
        [Display(Name = "Название команды")]
        [Required]
        public string Team { get; set; }
        
        [Display(Name = "Страна")]
        [Required]
        public string Country { get; set; }
    }
}