using System.ComponentModel.DataAnnotations;

namespace project.Models
{
    public class PlayerViewModel
    {
        [Display(Name = "Имя")]
        [Required]
        public string Name { get; set; }
        
        [Display(Name = "Фамилия")]
        [Required]
        public string Surname { get; set; }
        
        [Display(Name = "Пол")]
        [Required]
        public string Sex { get; set; }
        
        [Display(Name = "Дата рождения")]
        [Required]
        public int DateOfBirth { get; set; }
        
        [Display(Name = "Название команды")]
        [Required]
        public string Team { get; set; }
        
        [Display(Name = "Страна")]
        [Required]
        public string Country { get; set; }

        public PlayerViewModel(string name, string surname, string sex, int dateOfBirth, string team, string country)
        {
            Name = name;
            Surname = surname;
            Sex = sex;
            DateOfBirth = dateOfBirth;
            Team = team;
            Country = country;
        }
    }
}