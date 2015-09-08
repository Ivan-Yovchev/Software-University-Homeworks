namespace News.RestApi.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class NewsItemBindingModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}