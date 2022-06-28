using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookSelling.Models
{
    public class Reviews
    {
        /// <summary>
        /// Identificador da review
        /// </summary>
        [Key]
        public int IdReview { get; set; }

        /// <summary>
        /// Comentário do utilizador inscrito sobre o ad
        /// </summary>
        [Required]
        public string Comentario { get; set; }

        /// <summary>
        /// Pontuação que o utilizador dá ao artigo
        /// </summary>
        [Required]
        public int Pontuacao { get; set; }

        /// <summary>
        /// Data que o utilizador submeteu a review
        /// </summary>
        public DateTime Data { get; set; }

        /// <summary>
        /// Visibilidade da review
        /// </summary>
        public Boolean Visibilidade { get; set; }
        //********************************************
        /// <summary>
        /// FK para o utilizador que fez a review
        /// </summary>
        [ForeignKey(nameof(Utilizador))]
        public int? UtilizadoresFK { get; set; }
        public Utilizadores Utilizador { get; set; }

        /// <summary>
        /// FK para o advertisement ao qual review foi feita
        /// </summary>
        [ForeignKey(nameof(Adverts))]
        public int AdsFK { get; set; }
        public Advertisement Adverts { get; set; }
    }
}
