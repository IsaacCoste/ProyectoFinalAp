using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAp.Models;

public class Transacciones
{
    [Key]
    public int TransaccionId { get; set; }
    [ForeignKey("Usuarios")]
    public int UsuarioId { get; set; }
    [ForeignKey("Categorias")]
    public int CategoriaId { get; set; }
    [Range(0.01, 200000000, ErrorMessage = "Solo permite monto desde 0.01 hasta 200000000.")]
    [RegularExpression(@"^[0-9]", ErrorMessage = "Solo se permiten numeros.")]
    public float Monto { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime Fecha { get; set; }
    [Required(ErrorMessage = "Ingrese la Descripción")]
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚ0-9\s]+$", ErrorMessage = "Solo se permiten letras y numeros.")]
    public string Descripción { get; set; } = string.Empty;
    [Required(ErrorMessage = "Ingrese el Tipo de Transacción")]
    public string Tipo { get; set; } = string.Empty;
    public Usuarios? Usuario { get; set; }
    public Categorias? Categoria { get; set; }
}
