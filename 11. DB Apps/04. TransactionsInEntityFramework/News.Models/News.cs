using System.ComponentModel.DataAnnotations;

namespace News.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        [ConcurrencyCheck]
        public string NewsContent { get; set; }
    }
}
