namespace Backend.DTOs;

public class FiltrosProductoDto
{
    public string? Nombre { get; set; }

    public decimal? PrecioMin { get; set; }

    public decimal? PrecioMax { get; set; }

    public int? StockMin { get; set; }

    public int? StockMax { get; set; }

    public int Page { get; set; } = 1;

    public int PageSize { get; set; } = 10;
}