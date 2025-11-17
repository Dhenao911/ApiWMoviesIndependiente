using System.ComponentModel.DataAnnotations;

namespace Api.W.Movies.Backend.DAL.Models.Dtos
{
    //Dto para la creacion de una categoria sol con el nombre
    public class CategoryCreateDto
    {
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [MaxLength(100,ErrorMessage ="El campo {0} tiene maximo {1} caracteres")]
        public string Name { get; set; }
    }
}
