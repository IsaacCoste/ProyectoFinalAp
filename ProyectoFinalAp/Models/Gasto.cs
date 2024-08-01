using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAp.Models;

public class Gasto
{
    [Key]
    public int GastoId { get; set; }
    [ForeignKey("Cuenta")]
    public int CuentaId { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    [Range(0.1, 200000000, ErrorMessage = "El rango del monto debe estar entre 0.1 y 200000000.")]
    public float Monto { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public virtual Cuenta? Cuenta { get; set; }
}
