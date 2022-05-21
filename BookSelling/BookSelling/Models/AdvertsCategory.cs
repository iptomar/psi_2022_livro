using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookSelling.Models
{
    public class AdvertsCategory
    {
        /// <summary>
        /// PK para a tabela do relacionamento entre Filmes e Categorias
        /// </summary>
        [Key]
        public int IdAdvertsCategory { get; set; }

        //*
        /// <summary>
        /// Fk para Categoria
        /// </summary>
        [ForeignKey(nameof(Category))]
        public int CategoryFK { get; set; }
        public Category Category { get; set; }


        /// <summary>
        /// FK para o Filme
        /// </summary>
        [ForeignKey(nameof(Advertisement))]
        public int AdvertisementFK { get; set; }
        public Advertisement Advertisement { get; set; }
    }
}
