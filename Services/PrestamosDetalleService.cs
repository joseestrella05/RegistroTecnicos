using Microsoft.EntityFrameworkCore;
using RegistrosTecnico.DAL;
using RegistrosTecnico.Models;
using System.Linq.Expressions;

namespace RegistrosTecnico.Services;

public class PrestamosDetalleService(IDbContextFactory<Contexto> DbFactory)
{
  
    public async Task<List<PrestamosDetalle>> Listar(Expression<Func<PrestamosDetalle, bool>> criterio)
    {
        await using var context = await DbFactory.CreateDbContextAsync();
        return await context.PrestamosDetalle.Where(criterio).ToListAsync();
    }

    
    public async Task<bool> AgregarDetalle(int prestamoId, int cuotaNo, double valor, double balance)
    {
        await using var context = await DbFactory.CreateDbContextAsync();

        if (valor <= 0)
            throw new ArgumentException("Error, el valor de la cuota debe ser mayor que cero.");

        var detalle = new PrestamosDetalle
        {
            PrestamoId = prestamoId,
            CuotaNo = cuotaNo,
            Fecha = DateTime.Now.AddMonths(cuotaNo),
            Valor = valor,
            Balance = balance
        };

        context.PrestamosDetalle.Add(detalle);
        await context.SaveChangesAsync();
        return true;
    }

    // Método para eliminar detalles de un préstamo
    public async Task<bool> EliminarDetalles(int prestamoId)
    {
        await using var context = await DbFactory.CreateDbContextAsync();
        var detalles = await context.PrestamosDetalle
                                   .Where(d => d.PrestamoId == prestamoId)
                                   .ToListAsync();

        if (detalles.Any())
        {
            context.PrestamosDetalle.RemoveRange(detalles);
            await context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    
    public async Task<bool> CalcularCuotas(int prestamoId, double monto, int cantidadCuotas)
    {
        await using var context = await DbFactory.CreateDbContextAsync();

        if (cantidadCuotas <= 0 || monto <= 0)
            throw new ArgumentException("Error, el monto y la cantidad de cuotas deben ser mayores que cero.");

        await EliminarDetalles(prestamoId);

        double valorCuota = monto / cantidadCuotas;
        double balance = monto;

        List<PrestamosDetalle> nuevasCuotas = new();

        for (int i = 1; i <= cantidadCuotas; i++)
        {
            nuevasCuotas.Add(new PrestamosDetalle
            {
                PrestamoId = prestamoId,
                CuotaNo = i,
                Fecha = DateTime.Now.AddMonths(i),
                Valor = valorCuota,
                Balance = balance
            });
            balance -= valorCuota;
        }

        context.PrestamosDetalle.AddRange(nuevasCuotas);
        await context.SaveChangesAsync();
        return true;
    }
}
