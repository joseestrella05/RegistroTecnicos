using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistrosTecnico.Models;

public class PrestamosDetalle
{
    [Key]
    public int DetalleId { get; set; }

    public int PrestamoId { get; set; }

    public int CuotaNo {  get; set; }

    public DateTime Fecha { get; set; }

    public double Valor { get; set; }   

    public double Balance { get; set; }

    [ForeignKey("PrestamoId")]
    public virtual Prestamos Prestamos { get; set; } = null!;
}
