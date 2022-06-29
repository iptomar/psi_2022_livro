using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookSelling.Models
{
    public class Advertisement
    {
        public Advertisement()
        {
            // inicializar a lista de Categorias do Livro
            CategoriesList = new HashSet<AdvertsCategory>();
            ReviewsList = new HashSet<Reviews>();

        }

        /// <summary>
        /// Advertisement LinkID
        /// </summary>
        [Key]
        public int AdID { get; set; }

        /// <summary>
        /// Type of Add  (sell, rent, trade)
        /// </summary>
        [Required]
        public string TypeofAdd { get; set; }

        /// <summary>
        /// Title of the Add
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Price of the type of add
        /// </summary>
        [Required]
        public decimal Price { get; set; }


        /// <summary>
        /// Book code for searching in the api
        /// </summary>
        [Required]
        public string ISBM { get; set; }

        /// <summary>
        /// Boolean to see if the book was sold
        /// </summary>
        public Boolean sold { get; set; }

        ///// <summary>
        ///// List of the categories of the book
        ///// </summary>
        //public ICollection<Category> AddCategory { get; set; }
        
        /// <summary>
        /// Image of the book 
        /// </summary>
        public string Photo { get; set; }
        
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
        [ForeignKey(nameof(User))]
        public int UserID { get; set; }
        public Utilizadores User { get; set; }

        ///// <summary>
        ///// Foreign Key of Category
        ///// </summary>
        //[ForeignKey(nameof(Category))]
        //public int CategoryID { get; set; }
        //public Category Category { get; set; }

        /// <summary>
        /// List of the categories of the book
        /// </summary>
        public ICollection<AdvertsCategory> CategoriesList { get; set; }

        /// <summary>
        /// Lista das reviews dos advertisements
        /// </summary>
        public ICollection<Reviews> ReviewsList { get; set; }

    }
}
