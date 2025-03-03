using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistrosTecnico.Models;

public class CobrosDetalle
{
    [Key]
    public int DetalleId { get; set; }

    public int CobroId { get; set; }

    public int PrestamoId { get; set; }

    public double ValorCobrado { get; set; }
              
    [ForeignKey("CobroId")]
    [InverseProperty("CobrosDetalle")]
    public virtual Cobros Cobro { get; set; } = null!;

}
