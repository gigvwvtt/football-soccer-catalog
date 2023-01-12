using System.ComponentModel.DataAnnotations;

namespace project.Models.Custom_Validation_Attributes
{
    public class NotEqualToAttribute : ValidationAttribute
    {
        public string Text { get; set; }

        public NotEqualToAttribute(string text)
        {
            Text = text;
        }
        public override bool IsValid(object value)
        {
            return !value.ToString().Equals(Text);
        }
    }
}