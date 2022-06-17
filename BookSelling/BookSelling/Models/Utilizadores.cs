﻿using System.ComponentModel.DataAnnotations;

namespace BookSelling.Models
{
    public class Utilizadores
    {
        /// <summary>
        /// Construtor dos utilizadores
        /// </summary>
        public Utilizadores()
        {
            ReviewsList = new HashSet<Reviews>();
        }

        /// <summary>
        /// User ID
        /// </summary>
        [Key]
        public int UserID { get; set; }
        
        /// <summary>
        /// Username for the User
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Ligação entre os Utilizadores e a tabela de Autenticação
        /// </summary>
        public string ID { get; set; }

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
        [Required]
        public string Area { get; set; }

        /// <summary>
        /// Number of the books sold
        /// </summary>
        public int BooksSold { get; set; }

        /// <summary>
        /// Telephone number of the user 
        /// </summary>
        [Required]
        public int Telephone { get; set; }

        /// <summary>
        /// verifica se o utilizador já deu a sua "Review" ao filme
        /// </summary>
        public Boolean ControlarReview { get; set; }

        /// <summary>
        /// Lista das reviews dos utilizadores
        /// </summary>
        public ICollection<Reviews> ReviewsList { get; set; }

    }
}
