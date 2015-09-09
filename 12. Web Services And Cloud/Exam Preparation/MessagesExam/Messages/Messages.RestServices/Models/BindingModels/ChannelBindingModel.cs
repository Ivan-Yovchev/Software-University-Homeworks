namespace Messages.RestServices.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ChannelBindingModel
    {
        [Required]
        public string Name { get; set; }
    }
}