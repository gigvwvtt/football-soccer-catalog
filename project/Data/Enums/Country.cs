using System.ComponentModel.DataAnnotations;

namespace project.Data.Enums
{
    public enum Country
    {
        [Display(Name = "США")]
        USA = 1,
        [Display(Name = "Россия")]
        Russia = 2,
        [Display(Name = "Италия")]
        Italy = 3
    }
}