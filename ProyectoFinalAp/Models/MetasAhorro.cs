using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAp.Models;

public class MetasAhorro
{
    public int MetaDeAhorroId { get; set; }
    public int UsuarioId { get; set; }
    [Required(ErrorMessage = "Ingrese la Descripción.")]
    public string Nombre { get; set; }
    [Range(0.1, 200000000, ErrorMessage = "El rango del monto debe estar entre 0.1 y 200000000.")]
    [RegularExpression(@"^[0-9]", ErrorMessage = "Solo se permiten numeros.")]
    public decimal MontoObjetivo { get; set; }
    [Range(0.1, 200000000, ErrorMessage = "El rango del monto debe estar entre 0.1 y 200000000.")]
    [RegularExpression(@"^[0-9]", ErrorMessage = "Solo se permiten numeros.")]
    public decimal MontoAcumulado { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Required(ErrorMessage = "Ingrese la Fecha de Objetivo.")]
    public DateTime FechaObjetivo { get; set; }

    public Usuarios Usuario { get; set; }
}
