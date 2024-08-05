namespace ProyectoFinalAp.Models;

public class MetasAhorro
{
    public int MetaDeAhorroId { get; set; }
    public int UsuarioId { get; set; }
    public string Nombre { get; set; }
    public decimal MontoObjetivo { get; set; }
    public decimal MontoAcumulado { get; set; }
    public DateTime FechaObjetivo { get; set; }

    public Usuario Usuario { get; set; }
}
