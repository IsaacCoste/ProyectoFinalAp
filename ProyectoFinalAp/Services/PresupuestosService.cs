using Microsoft.EntityFrameworkCore;
using ProyectoFinalAp.Data;
using ProyectoFinalAp.Models;
using System.Linq.Expressions;

namespace ProyectoFinalAp.Services;

public class PresupuestosService(ApplicationDbContext contexto)
{
    private readonly ApplicationDbContext _contexto = contexto;

    private async Task<bool> Insertar(Presupuestos presupuesto)
    {
        _contexto.Presupuestos.Add(presupuesto);
        return await _contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Presupuestos presupuesto)
    {
        _contexto.Update(presupuesto);
        var modifico = await _contexto.SaveChangesAsync() > 0;
        _contexto.Entry(presupuesto).State = EntityState.Detached;
        return modifico;
    }
    public async Task<bool> Existe(int presupuestoId)
    {
        return await _contexto.Presupuestos
            .AnyAsync(u => u.PresupuestoId == presupuestoId);
    }
    public async Task<bool> Existe(int presupuestoId, string? descripcion)
    {
        return await _contexto.Presupuestos
            .AnyAsync(a => a.PresupuestoId != presupuestoId
            && a.Descripcion.Equals(descripcion));
    }
    public async Task<bool> Guardar(Presupuestos presupuesto)
    {
        if (!await Existe(presupuesto.PresupuestoId))
            return await Insertar(presupuesto);
        else
            return await Modificar(presupuesto);
    }
    public async Task<bool> Eliminar(int id)
    {
        var cantidad = await _contexto.Presupuestos
            .Where(a => a.PresupuestoId == id)
            .ExecuteDeleteAsync();
        return cantidad > 0;
    }
    public async Task<Presupuestos?> Buscar(int id)
    {
        return await _contexto.Presupuestos
            .Include(p => p.DetallesGastosPresupuesto)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.PresupuestoId == id);
    }
    public async Task<List<Presupuestos>> Listar(Expression<Func<Presupuestos, bool>> criterio)
    {
        return await _contexto.Presupuestos.Include(p => p.DetallesGastosPresupuesto)
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
