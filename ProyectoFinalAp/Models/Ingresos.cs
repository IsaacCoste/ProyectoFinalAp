using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAp.Models;

public class Ingresos
{
    [Key]
    public int IngresoId { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Required(ErrorMessage = "Ingrese la Fecha.")]
    public DateTime Fecha { get; set; } = DateTime.Now;
    [ForeignKey("CategoriaId")]
    public int CategoriaId { get; set; }
    [Required(ErrorMessage = "Ingrese el Concepto")]
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "Solo se permiten letras.")]
    public string Concepto { get; set; } = string.Empty;
    [Required(ErrorMessage = "Ingrese el Monto")]
    [Range(0.1, 200000000, ErrorMessage = "El rango del monto debe estar entre 0.1 y 200000000.")]
    [RegularExpression(@"^[0-9]", ErrorMessage = "Solo se permiten numeros.")]
    public float Monto { get; set; }
}
