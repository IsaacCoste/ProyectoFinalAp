using Microsoft.EntityFrameworkCore;
using ProyectoFinalAp.Data;
using ProyectoFinalAp.Models;
using System.Linq.Expressions;

namespace ProyectoFinalAp.Services;

public class IngresosService(ApplicationDbContext contexto)
{
    private readonly ApplicationDbContext _contexto = contexto;
    private async Task<bool> Insertar(Ingresos ingreso)
    {
        _contexto.Ingresos.Add(ingreso);
        return await _contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Ingresos ingreso)
    {
        _contexto.Update(ingreso);
        var modifico = await _contexto.SaveChangesAsync() > 0;
        _contexto.Entry(ingreso).State = EntityState.Detached;
        return modifico;
    }
    public async Task<bool> Existe(int ingresoId)
    {
        return await _contexto.Ingresos
            .AnyAsync(u => u.IngresoId == ingresoId);
    }
    public async Task<bool> Existe(int ingresoId, DateTime? fecha)
    {
        return await _contexto.Ingresos
            .AnyAsync(a => a.IngresoId != ingresoId
            && a.Fecha.Equals(fecha));
    }
    public async Task<bool> Guardar(Ingresos ingreso)
    {
        if (!await Existe(ingreso.IngresoId))
            return await Insertar(ingreso);
        else
            return await Modificar(ingreso);
    }
    public async Task<bool> Eliminar(int id)
    {
        var cantidad = await _contexto.Ingresos
            .Where(a => a.IngresoId == id)
            .ExecuteDeleteAsync();
        return cantidad > 0;
    }
    public async Task<Ingresos?> Buscar(int id)
    {
        return await _contexto.Ingresos
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.IngresoId == id);
    }
    public async Task<List<Ingresos>> Listar(Expression<Func<Ingresos, bool>> criterio)
    {
        return await _contexto.Ingresos
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
