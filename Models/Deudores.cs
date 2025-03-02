using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistrosTecnico.Models;

public class Deudores
{
    [Key]
    public int DeudorId { get; set; }

    public string Nombres { get; set; } = null!;

    [InverseProperty("Deudor")]
    public virtual ICollection<Cobros> Cobros { get; set; } = new List<Cobros>();

    [InverseProperty("Deudor")]
    public virtual ICollection<Prestamos> Prestamos { get; set; } = new List<Prestamos>();
}
