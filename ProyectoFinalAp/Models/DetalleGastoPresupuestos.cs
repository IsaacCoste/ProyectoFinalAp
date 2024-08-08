using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAp.Models;

public class DetalleGastoPresupuestos
{
    [Key]
    public int DetalleGastoId { get; set; }
    [ForeignKey("PresupuestoId")]
    public int PresupuestoId { get; set; }
    [Required(ErrorMessage = "Ingrese la Descripción.")]
    public string Descripcion { get; set; } = string.Empty;
    [Range(0.1, 200000000, ErrorMessage = "El rango del monto debe estar entre 0.1 y 200000000.")]
    public float Monto { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime FechaAsignacion { get; set; } = DateTime.Now;
    public virtual Presupuestos? Presupuesto { get; set; }
}
