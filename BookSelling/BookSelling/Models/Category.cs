using System.ComponentModel.DataAnnotations;

namespace BookSelling.Models
{
    public class Category
    {
        /// <summary>
        /// Id for Category
        /// </summary>
        [Key]
        public int IdCategory { get; set; }

        /// <summary>
        /// Name of the Category
        /// </summary>
        [Required]
        public string NameCategory { get; set; }
    }
}