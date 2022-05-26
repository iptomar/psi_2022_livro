using System.ComponentModel.DataAnnotations;

namespace BookSelling.Models
{
    public class Category
    {
        public Category()
        {
            // inicializar a lista de Categorias do Livro
            CategoriesList = new HashSet<AdvertsCategory>();
        }

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

        /// <summary>
        /// Lista de categorias
        /// </summary>
        public ICollection<AdvertsCategory> CategoriesList { get; set; }
    }
}