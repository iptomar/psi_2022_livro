using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookSelling.Models
{
    public class Advertisement
    {
        /// <summary>
        /// Advertisement ID
        /// </summary>
        [Key]
        public int AdID { get; set; }

        /// <summary>
        /// Type of Add  (sell, rent, trade)
        /// </summary>
        public string TypeofAdd { get; set; }

        /// <summary>
        /// Price of the type of add
        /// </summary>
        public decimal Price { get; set; }


        /// <summary>
        /// Book code for searching in the api
        /// </summary>
        public string ISBM { get; set; }

        /// <summary>
        /// Boolean to see if the book was sold
        /// </summary>
        public Boolean sold { get; set; }

        /// <summary>
        /// List of the categories of the book
        /// </summary>
        //public ICollection<Category> Category { get; set; }
        
        /// <summary>
        /// Image of the book 
        /// </summary>
        public string Imagem { get; set; }
        
        /// <summary>
        /// Description of the add 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Visibility of the add
        /// </summary>
        public Boolean Visibility { get; set; }

        /// <summary>
        /// Date of the add
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Foreign Key of User 
        /// </summary>
        //[ForeignKey(nameof(User))]
        //public int UserID { get; set; }
        //public User User { get; set; }
    }
}
