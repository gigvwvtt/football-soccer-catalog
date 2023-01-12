using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using project.Models.Custom_Validation_Attributes;

namespace project.Models
{
    public class PlayerModelView
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerId { get; set; }
        
        [Required(ErrorMessage = "Не может быть пустым")]
        [Display(Name = "Имя")]
        [DataType(DataType.Text)]
        [MinLength(3)]
        [MaxLength(15)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Не может быть пустым")]
        [Display(Name = "Фамилия")]
        [DataType(DataType.Text)]
        [MinLength(3)]
        [MaxLength(15)]
        public string Surname { get; set; }
        
        [Display(Name = "Пол")]
        [Required(ErrorMessage = "Не выбрано")]
        [NotEqualTo("Пол")]
        [MaxLength(1)]
        public string Sex { get; set; }
        
        [Display(Name = "Дата рождения")]
        [Required(ErrorMessage = "Не выбрано")]  
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        
        [Display(Name = "Название команды")]
        [Required(ErrorMessage = "Не может быть пустым")]
        [MaxLength(10)]
        public string Team { get; set; }
        
        [Display(Name = "Страна")]
        [Required(ErrorMessage = "Не выбрано")]
        [NotEqualTo("Страна")]
        [MaxLength(20)]
        public string Country { get; set; }
    }
}

public enum Sex
{
    м,
    ж
}

public enum Country
{
    США,
    Россия,
    Италия
}