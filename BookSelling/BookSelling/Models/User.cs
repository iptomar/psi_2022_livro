using System.ComponentModel.DataAnnotations;

namespace BookSelling.Models
{
    public class User
    {
        /// <summary>
        /// User ID
        /// </summary>
        public int UserID { get; set; }
        
        /// <summary>
        /// Username for the User
        /// </summary>
        [Required]
        public string UserName { get; set; }


        /// <summary>
        /// Email do Utilizador
        /// </summary>
        [Required(ErrorMessage = "This is required!")]
        [StringLength(50, ErrorMessage = "The {0} can't be more than {1} letters.")]
        public string Email { get; set; }

        /// <summary>
        /// Reputation of the User
        /// </summary>
        public decimal Reputation { get; set; }

        /// <summary>
        /// Area where the User lives
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// Number of the books sold
        /// </summary>
        public int BooksSold { get; set; }

        /// <summary>
        /// Telephone number of the user 
        /// </summary>
        public int Telephone { get; set; }

       
    }
}
