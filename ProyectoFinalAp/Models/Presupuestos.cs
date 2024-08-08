using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAp.Models;

public class Presupuestos
{
    [Key]
    public int PresupuestoId { get; set; }
    [Required(ErrorMessage ="Ingrese la Descripción.")]
    public string Descripcion { get; set; } = string.Empty;
    [Range(0.1, 200000000, ErrorMessage = "El rango del monto debe estar entre 0.1 y 200000000.")]
    [RegularExpression(@"^[0-9]", ErrorMessage = "Solo se permiten numeros.")]
    public float MontoAsignado { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime FechaInicio { get; set; } = DateTime.Now;
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Required(ErrorMessage = "Ingrese la Fecha de Fin.")]
    public DateTime FechaFin { get; set; } = DateTime.Now;
    public virtual Usuarios? Usuario { get; set; }
    public virtual ICollection<DetalleGastoPresupuestos> DetallesGastosPresupuesto { get; set; } = new List<DetalleGastoPresupuestos>();
}
