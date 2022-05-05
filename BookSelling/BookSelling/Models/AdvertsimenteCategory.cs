//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace BookSelling.Models
//{
//    public class AdvertsimenteCategory
//    {
//        /// <summary>
//        /// PK para a tabela do relacionamento entre Filmes e Categorias
//        /// </summary>
//        [Key]
//        public int IdAdsCategories { get; set; }

//        //*
//        /// <summary>
//        /// Fk para Categoria
//        /// </summary>
//        [ForeignKey(nameof(Category))]
//        public int CategoriasFK { get; set; }
//        public Category Categoria { get; set; }


//        /// <summary>
//        /// FK for Advertisemnet
//        /// </summary>
//        [ForeignKey(nameof(Advertisement))]
//        public int AdvertisementFK { get; set; }
//        public Advertisement Advertisement { get; set; }
//    }
//}
