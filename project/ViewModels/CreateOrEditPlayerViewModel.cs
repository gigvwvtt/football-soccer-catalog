using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using project.Data.Enums;
using project.Models;

namespace project.ViewModels
{
    public class CreateOrEditPlayerViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не может быть пустым")]
        [Display(Name = "Имя")]
        [MinLength(3, ErrorMessage = "Минимум 3 символа")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не может быть пустым")]
        [Display(Name = "Фамилия")]
        [MinLength(3, ErrorMessage = "Минимум 3 символа")]
        public string Surname { get; set; }
        [Display(Name = "Пол")]
        [Required(ErrorMessage = "Не выбрано")]
        public Sex Sex { get; set; }
        [Display(Name = "Дата рождения")]
        [Required(ErrorMessage = "Не выбрано")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        public int? TeamId { get; set; }
        [Display(Name = "Название команды")]
        [Required(ErrorMessage = "Не может быть пустым")]
        public Team? Team { get; set; }
        [Display(Name = "Страна")]
        [Required(ErrorMessage = "Не выбрано")]
        public Country Country { get; set; }
        public List<string> AvailableTeams { get; set; }
    }
}