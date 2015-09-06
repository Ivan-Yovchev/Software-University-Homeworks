namespace ProductShop.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Product
    {
        private ICollection<Category> categories;

        public Product()
        {
            this.categories = new HashSet<Category>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Product Name Must Be At Least 3 Characters Long")]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int? BuyerId { get; set; }

        // Creates And Additional Relationship In Database (User_Id)
        // Remove for an exact copy of the diagram given in the homework assignment
        public virtual User Buyer { get; set; }

        [Required]
        public int SellerId { get; set; }

        // Creates And Additional Relationship In Database (User_Id1)
        // Remove for an exact copy of the diagram given in the homework assignment
        public virtual User Seller { get; set; }

        public virtual ICollection<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        } 
    }
}
