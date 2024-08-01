using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAp.Models;

public class Cuenta
{
    [Key]
    public int CuentaId { get; set; }
    [ForeignKey("Usuario")]
    public int UsuarioId { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    [Range(0.1, 200000000, ErrorMessage = "El rango del monto debe estar entre 0.1 y 200000000.")]
    public float Saldo { get; set; }
    public DateTime FechaCreacion { get; set; }
    public virtual Usuario? Usuario { get; set; }
    [ForeignKey("CuentaId")]
    public virtual ICollection<Ingreso> Ingresos { get; set; } = new List<Ingreso>();
    [ForeignKey("CuentaId")]
    public virtual ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();
}
