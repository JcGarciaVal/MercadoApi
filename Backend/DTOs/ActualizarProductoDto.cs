using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs;

public class ActualizarProductoDto
{
    [Required]
    public string Nombre { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0.")]
    public decimal Precio { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
    public int Stock { get; set; }
}