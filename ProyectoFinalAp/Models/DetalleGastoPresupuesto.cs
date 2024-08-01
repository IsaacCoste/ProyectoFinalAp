using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAp.Models;

public class DetalleGastoPresupuesto
{
    [Key]
    public int DetalleGastoId { get; set; }
    [ForeignKey("Presupuesto")]
    public int PresupuestoId { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    [Range(0.1, 200000000, ErrorMessage = "El rango del monto debe estar entre 0.1 y 200000000.")]
    public float Monto { get; set; }
    public DateTime FechaAsignacion { get; set; } = DateTime.Now;
    public virtual Presupuesto? Presupuesto { get; set; }

}
