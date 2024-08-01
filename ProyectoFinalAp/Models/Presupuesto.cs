using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAp.Models;

public class Presupuesto
{
    [Key]
    public int PresupuestoId { get; set; }
    [ForeignKey("Usuario")]
    public int UsuarioId { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    [Range(0.1, 200000000, ErrorMessage = "El rango del monto debe estar entre 0.1 y 200000000.")]
    public float MontoAsignado { get; set; }
    public DateTime FechaInicio { get; set; } = DateTime.Now;
    public DateTime FechaFin { get; set; }
    public float TotalGastos { get; set; }
    public virtual Usuario? Usuario { get; set; }
    [ForeignKey("PresupuestoId")]
    public virtual ICollection<DetalleGastoPresupuesto> DetallesGastosPresupuesto { get; set; } = new List<DetalleGastoPresupuesto>();
}
