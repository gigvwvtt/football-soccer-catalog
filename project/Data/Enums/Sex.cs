using System.ComponentModel.DataAnnotations;

namespace project.Data.Enums
{
    public enum Sex
    {
        [Display(Name = "муж")]
        м = 1,
        [Display(Name = "жен")]
        ж = 2
    }
}