using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookSelling.Models
{
    public class Favorite
    {
        /// <summary>
        /// Identificador do favorito
        /// </summary>
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Advertisement))]
        public int AdvertisementID { get; set; }
        public Advertisement Advertisement { get; set; }

        [ForeignKey(nameof(Utilizadores))]
        public int UtilizadoresID { get; set; }
        public Utilizadores Utilizadores { get; set; }


    }
}
