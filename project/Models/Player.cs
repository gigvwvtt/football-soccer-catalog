using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using project.Data.Enums;

namespace project.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Не может быть пустым")]
        [Display(Name = "Имя")]
        [MinLength(3)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не может быть пустым")]
        [Display(Name = "Фамилия")]
        [MinLength(3)]
        public string Surname { get; set; }
        [Display(Name = "Пол")]
        [Required(ErrorMessage = "Не выбрано")]
        public Sex Sex { get; set; }
        [Display(Name = "Дата рождения")]
        [Required(ErrorMessage = "Не выбрано")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        [ForeignKey("Team")] 
        public int? TeamId { get; set; }
        [Display(Name = "Название команды")]
        public Team? Team { get; set; }
        [Display(Name = "Страна")]
        [Required(ErrorMessage = "Не выбрано")]
        public Country Country { get; set; }
    }
}