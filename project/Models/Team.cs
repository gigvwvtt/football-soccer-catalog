using System.ComponentModel.DataAnnotations;

namespace project.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Не может быть пустым")]
        public string Name { get; set; }
    }
}