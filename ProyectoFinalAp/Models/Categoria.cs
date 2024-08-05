namespace ProyectoFinalAp.Models;

public class Categoria
{
    public int CategoriaId { get; set; }
    public string Nombre { get; set; }
    public string Tipo { get; set; }

    public ICollection<Transaccion> Transacciones { get; set; }

    public ICollection<Presupuesto> Presupuestos { get; set; }
}
