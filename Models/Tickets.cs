using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistrosTecnico.Models;

public class Tickets
{
    [Key]
    public int TicketId { get; set; }

    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "El Campo es obligatorio")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "No se permiten Numero")]
    public string? Prioridad { get; set; }

    [Required(ErrorMessage = "El campo es obligatoria")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "No se permiten Numero")]
    public string? Asunto { get; set; }

    [Required(ErrorMessage = "El Campo es obligatorio.")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "No se permiten Numero")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "El Campo es obligatorio.")]
    [RegularExpression(@"^[A-Z0-9\d{2}]+$", ErrorMessage = "Solo se permiten Numero")]
    public string? TiempoLimite { get; set; }

    [Required(ErrorMessage = "El Campus es obligatorio.")]
    public int TecnicoId { get; set; }

    [ForeignKey("TecnicoId")]
    public virtual Tecnicos Tecnicos { get; set; } = null!;

    [Required(ErrorMessage = "El Campus es obligatorio.")]
    public int ClienteId { get; set; }

    [ForeignKey("ClienteId")]
    public virtual Clientes Clientes { get; set; } = null!;
}
