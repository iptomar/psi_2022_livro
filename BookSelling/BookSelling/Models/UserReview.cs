using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookSelling.Models
{
    public class UserReview
    {
        /// <summary>
        /// Id da review
        /// </summary>
        [Key]
        public int IdReview { get; set; }

        /// <summary>
        /// Nota da Review que o utilizador dará
        /// </summary>
        [Required]
        public double ValueReview { get; set; }

        /// <summary>
        /// Data em que a review foi feita
        /// </summary>
        public DateTime DateReview { get; set; }

        //****************************************

        /// <summary>
        /// FK used to the reviewer of the user
        /// </summary>        
        [ForeignKey(nameof(Utilizador))]
        public int UtilizadorFK { get; set; }
        public Utilizadores Utilizador { get; set; }

        /// <summary>
        /// FK used to the reviewed user
        /// </summary>
        [ForeignKey(nameof(Utilizador2))]
        public int Utilizador2FK { get; set; }
        public Utilizadores Utilizador2 { get; set; }
    }
}
