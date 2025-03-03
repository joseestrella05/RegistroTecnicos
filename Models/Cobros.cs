﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistrosTecnico.Models;

public class Cobros
{
    [Key]
    public int CobroId { get; set; }

    public DateTime Fecha { get; set; }

    public int DeudorId { get; set; }

    [Range(1, double.MaxValue, ErrorMessage = "Debe introducir un monto valido")]
    public double Monto { get; set; }

    [InverseProperty("Cobro")]
    public virtual ICollection<CobrosDetalle> CobrosDetalle { get; set; } = new List<CobrosDetalle>();

    [ForeignKey("DeudorId")]
    [InverseProperty("Cobros")]
    public virtual Deudores Deudor { get; set; } = null!;
}
