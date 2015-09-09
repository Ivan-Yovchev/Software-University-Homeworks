namespace Messages.RestServices.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class MessageBindingModel
    {
        [Required]
        [MinLength(1)]
        public string Text { get; set; }
    }
}