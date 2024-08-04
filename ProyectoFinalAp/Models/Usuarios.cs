using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAp.Models;

public class Usuarios
{
    [Key]
    public int UsuarioId { get; set; }
    [ForeignKey("AspNetUser")]
    public string UserId { get; set; } = string.Empty;

    [ForeignKey("AspNetRole")]
    public string RolId { get; set; } = null!;
    public string Nombre { get; set; } = string.Empty;
    public DateTime FechaRegistro { get; set; }
    [ForeignKey("UsuarioId")]
    public virtual ICollection<Transacciones> Transacciones { get; set; } = new List<Transacciones>();
    [ForeignKey("UsuarioId")]
    public virtual ICollection<Presupuestos> Presupuestos { get; set; } = new List<Presupuestos>();
}
