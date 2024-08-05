namespace ProyectoFinalAp.Models;

public class Transaccion
{
    public int TransaccionId { get; set; }
    public int UsuarioId { get; set; }
    public int CategoriaId { get; set; }
    public decimal Monto { get; set; }
    public DateTime Fecha { get; set; }
    public string Descripción { get; set; }
    public string Tipo { get; set; }

    public Usuario Usuario { get; set; }

    public Categoria Categoria { get; set; }
}
