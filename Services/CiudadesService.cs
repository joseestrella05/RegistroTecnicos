using Microsoft.EntityFrameworkCore;
using RegistrosTecnico.DAL;
using RegistrosTecnico.Models;
using System.Linq.Expressions;

namespace RegistrosTecnico.Services;

public class CiudadesService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Ciudades.AnyAsync(c => c.CiudadesId == id);
    }

    private async Task<bool> Insertar(Ciudades ciudades)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Ciudades.Add(ciudades);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Ciudades ciudades)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var local = _context.Ciudades.Local
            .FirstOrDefault(c => c.CiudadesId == ciudades.CiudadesId);

        _context.Entry(ciudades).State = EntityState.Modified;

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Ciudades ciudades)
    {
        if (!await Existe(ciudades.CiudadesId))
            return await Insertar(ciudades);
        else
            return await Modificar(ciudades);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var ciudades = await contexto.Ciudades
            .Where(c => c.CiudadesId == id).ExecuteDeleteAsync();
        return ciudades > 0;
    }

    public async Task<Ciudades?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Ciudades.AsNoTracking().
            FirstOrDefaultAsync(c => c.CiudadesId == id);
    }

    public async Task<Ciudades?> BuscarNombres(string nombre)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Ciudades.AsNoTracking()
            .FirstOrDefaultAsync(t => t.Nombres == nombre);
    }

    public async Task<List<Ciudades>> Listar(Expression<Func<Ciudades, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Ciudades.AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
