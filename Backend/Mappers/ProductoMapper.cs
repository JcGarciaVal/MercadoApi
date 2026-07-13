using Backend.DTOs;
using Backend.Models;

namespace Backend.Mappers;

public static class ProductoMapper
{
    public static ProductoDto ToDto(Producto producto)
    {
        return new ProductoDto
        {
            Id = producto.Id,
            Nombre = producto.Nombre,
            Precio = producto.Precio,
            Stock = producto.Stock
        };
    }

    public static Producto ToEntity(CrearProductoDto dto)
    {
        return new Producto
        {
            Nombre = dto.Nombre,
            Precio = dto.Precio,
            Stock = dto.Stock
        };
    }

    public static Producto ToEntity(ActualizarProductoDto dto)
    {
        return new Producto
        {
            Nombre = dto.Nombre,
            Precio = dto.Precio,
            Stock = dto.Stock
        };
    }
}