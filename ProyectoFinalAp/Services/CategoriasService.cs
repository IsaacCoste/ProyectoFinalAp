using Microsoft.EntityFrameworkCore;
using ProyectoFinalAp.Data;
using ProyectoFinalAp.Models;
using System.Linq.Expressions;

namespace ProyectoFinalAp.Services;

public class CategoriasService(ApplicationDbContext contexto)
{
    private readonly ApplicationDbContext _contexto = contexto;

    private async Task<bool> Insertar (Categorias categoria)
    {
        _contexto.Categorias.Add(categoria);
        return await _contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Categorias categoria)
    {
        _contexto.Categorias.Update(categoria);
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Existe(int categoriaId)
    {
        return await _contexto.Categorias
            .AnyAsync(c => c.CategoriaId == categoriaId);
    }
    public async Task<bool> Existe(int categoriaId, string? nombre)
    {
        return await _contexto.Categorias
            .AnyAsync(c => c.CategoriaId != categoriaId
            && c.Nombre.Equals(nombre));
    }
    public async Task<bool> Guardar(Categorias categoria)
    {
        if (!await Existe(categoria.CategoriaId))
            return await Insertar(categoria);
        else
            return await Modificar(categoria);
    }
    public async Task<bool> Eliminar(Categorias categoria)
    {
        var cantidad = await _contexto.Categorias
            .Where(c => c.CategoriaId == categoria.CategoriaId)
            .ExecuteDeleteAsync();
        return cantidad > 0;
    }
    public async Task<Categorias?> Buscar(int categoriaId)
    {
        return await _contexto.Categorias
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.CategoriaId == categoriaId);
    }
    public async Task<List<Categorias>> Listar(Expression<Func<Categorias, bool>> criterio)
    {
        return await _contexto.Categorias
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
