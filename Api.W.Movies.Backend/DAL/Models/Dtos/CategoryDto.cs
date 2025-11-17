using System.ComponentModel.DataAnnotations;

namespace Api.W.Movies.Backend.DAL.Models.Dtos
{
    /// <summary>
    ///Dtos a imagen y semesjansa de la entidad Category
    /// </summary>
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} tiene maximo {1} caracteres")] 
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}