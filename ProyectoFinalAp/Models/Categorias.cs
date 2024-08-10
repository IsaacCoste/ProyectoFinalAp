using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAp.Models;

public class Categorias
{
    [Key]
    public int CategoriaId { get; set; }
    [Required(ErrorMessage = "Ingrese el Nombre")]
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "Solo se permiten letras.")]
    public string Nombre { get; set; } = string.Empty;
    [Required(ErrorMessage = "Ingrese el Tipo de categoria")]
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "Solo se permiten letras.")]
    public string Tipo { get; set; } = string.Empty;
    public virtual ICollection<Gastos> Gastos { get; set; } = new List<Gastos>();
}
