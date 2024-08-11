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
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Existe(int gastoId)
    {
        return await _contexto.Gastos
            .AnyAsync(g => g.GastoId == gastoId);
    }
    public async Task<bool> Existe(int gastoId, string? concepto)
    {
        return await _contexto.Gastos
            .AnyAsync(g => g.GastoId != gastoId
            && g.Concepto.Equals(concepto));
    }
    public async Task<bool> Guardar(Gastos gasto)
    {
        if (!await Existe(gasto.GastoId))
            return await Insertar(gasto);
        else
            return await Modificar(gasto);
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
