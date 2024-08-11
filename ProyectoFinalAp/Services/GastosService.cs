using Microsoft.EntityFrameworkCore;
using ProyectoFinalAp.Data;
using ProyectoFinalAp.Models;
using System.Linq.Expressions;

namespace ProyectoFinalAp.Services;

public class GastosService(ApplicationDbContext contexto)
{
    private readonly ApplicationDbContext _contexto = contexto;

    private async Task<bool> Insertar(Gastos gasto)
    {
        _contexto.Gastos.Add(gasto);
        return await _contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Gastos gasto)
    {
        _contexto.Gastos.Update(gasto);
        var modifico = await _contexto.SaveChangesAsync() > 0;
        _contexto.Entry(gasto).State = EntityState.Detached;
        return modifico;
    }
    public async Task<bool> Existe(int gastoId)
    {
        return await _contexto.Gastos
            .AnyAsync(g => g.GastoId == gastoId);
    }
    public async Task<bool> Existe(int gastoId, DateTime? fecha)
    {
        return await _contexto.Gastos
            .AnyAsync(g => g.GastoId != gastoId
            && g.Fecha.Equals(fecha));
    }
    public async Task<bool> Guardar(Gastos gasto)
    {
        var presupuesto = await _contexto.Presupuestos
            .Where(p => p.FechaInicio <= gasto.Fecha && p.FechaFin >= gasto.Fecha)
            .FirstOrDefaultAsync();

        if (presupuesto == null)
        {
            return false;
        }

        var ingresosTotal = await _contexto.Ingresos
            .Where(i => i.Fecha >= presupuesto.FechaInicio && i.Fecha <= presupuesto.FechaFin)
            .SumAsync(i => i.Monto);

        var gastosTotales = await _contexto.Gastos
            .Where(g => g.Fecha >= presupuesto.FechaInicio && g.Fecha <= presupuesto.FechaFin)
            .SumAsync(g => g.Monto);

        var maximoGastoPermitido = Math.Min(presupuesto.MontoAsignado, ingresosTotal) - gastosTotales;

        if (gasto.Monto > maximoGastoPermitido)
        {
            return false;
        }

        if (!await Existe(gasto.GastoId))
        {
            return await Insertar(gasto);
        }
        else
        {
            return await Modificar(gasto);
        }
    }
    public async Task<bool> Eliminar(Gastos gasto)
    {
        var cantidad = await _contexto.Gastos
            .Where(g => g.GastoId == gasto.GastoId)
            .ExecuteDeleteAsync();
        return cantidad > 0;
    }
    public async Task<Gastos?> Buscar(int gastoId)
    {
        return await _contexto.Gastos
            .Include(g => g.Categoria)
            .AsNoTracking()
            .FirstOrDefaultAsync(g => g.GastoId == gastoId);
    }
    public async Task<List<Gastos>> Listar(Expression<Func<Gastos, bool>> criterio)
    {
        return await _contexto.Gastos
            .Include(g => g.Categoria)
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
    public async Task<List<Categorias>> GetCategorias()
    {
        return await _contexto.Categorias
            .AsNoTracking()
            .ToListAsync();
    }
}
