using Microsoft.EntityFrameworkCore;
using ProyectoFinalAp.Data;
using ProyectoFinalAp.Models;
using System.Linq.Expressions;

namespace ProyectoFinalAp.Services;

public class UsuariosService(ApplicationDbContext contexto)
{
    private readonly ApplicationDbContext _contexto = contexto;

    private async Task<bool> Insertar(Usuarios usuario)
    {
        _contexto.Usuarios.Add(usuario);
        return await _contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Usuarios usuario)
    {
        _contexto.Usuarios.Update(usuario);
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Existe(int usuarioId)
    {
        return await _contexto.Usuarios
            .AnyAsync(u => u.UsuarioId == usuarioId);
    }
    public async Task<bool> Existe(int usuarioId, string? nombre)
    {
        return await _contexto.Usuarios
            .AnyAsync(a => a.UsuarioId != usuarioId 
            && a.Nombre.Equals(nombre));
    }
    public async Task<bool> Guardar(Usuarios usuario)
    {
        if (!await Existe(usuario.UsuarioId))
            return await Insertar(usuario);
        else
            return await Modificar(usuario);
    }
    public async Task<bool> Eliminar(Usuarios usuario)
    {
        var cantidad = await _contexto.Usuarios
            .Where(a => a.UsuarioId == usuario.UsuarioId)
            .ExecuteDeleteAsync();
        return cantidad > 0;
    }
    public async Task<Usuarios?> Buscar(int usuarioId)
    {
        return await _contexto.Usuarios
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.UsuarioId == usuarioId);
    }
    public async Task<List<Usuarios>> Listar(Expression<Func<Usuarios, bool>> criterio)
    {
        return await _contexto.Usuarios
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
