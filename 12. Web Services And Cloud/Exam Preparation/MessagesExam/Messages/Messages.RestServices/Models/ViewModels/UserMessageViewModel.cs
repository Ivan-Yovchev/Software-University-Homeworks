namespace Messages.RestServices.Models.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserMessageViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime DateSent { get; set; }

        [Required]
        public string Sender { get; set; }
    }
}