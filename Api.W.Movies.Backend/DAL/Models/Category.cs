using System.ComponentModel.DataAnnotations;

namespace Api.W.Movies.Backend.DAL.Models;

public class Category : AuditBase
{
    [Required] // El campo es obligatorio
    [Display(Name="Category Name")] // Nombre para mostrar en la interfaz de usuario
    public string Name { get; set; }
}