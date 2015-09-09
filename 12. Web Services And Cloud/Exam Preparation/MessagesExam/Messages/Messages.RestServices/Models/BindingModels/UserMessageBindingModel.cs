namespace Messages.RestServices.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class UserMessageBindingModel
    {
        [Required]
        public string Recipient { get; set; }

        [Required]
        [MinLength(1)]
        public string Text { get; set; }
    }
}