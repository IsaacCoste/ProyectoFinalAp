using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAp.Models;

public class Usuario
{
    [Key]
    public int UsuarioId { get; set; }
    [ForeignKey("AspNetUser")]
    public string UserId { get; set; } = string.Empty;

    [ForeignKey("AspNetRole")]
    public string RolId { get; set; } = null!;
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime FechaRegistro { get; set; }
    [ForeignKey("UsuarioId")]
    public virtual ICollection<Cuenta> Cuentas { get; set; } = new List<Cuenta>();
    [ForeignKey("UsuarioId")]
    public virtual ICollection<Presupuesto> Presupuestos { get; set; } = new List<Presupuesto>();
}
