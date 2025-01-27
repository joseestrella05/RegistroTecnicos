using System.ComponentModel.DataAnnotations;

namespace RegistrosTecnico.Models;

public class Ciudades
{
    [Key]
    public int CiudadesId { get; set; }

    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "No se permiten Numero")]
    [Required(ErrorMessage = "El Nombres obligatorio")]
    public string? Nombres { get; set; }
}
