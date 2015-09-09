namespace Messages.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserMessage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime DateSent { get; set; }

        public virtual User SenderUser { get; set; }

        [Required]
        public virtual User RecieverUser { get; set; }
    }
}
