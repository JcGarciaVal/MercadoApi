using Backend.Interfaces;
using Backend.DTOs;
using Backend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductoController : ControllerBase
{
    private readonly IProductoService _productoService;

    public ProductoController(IProductoService productoService)
    {

        _productoService = productoService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var producto = await _productoService.ObtenerPorId(id);

        var productoDto = ProductoMapper.ToDto(producto);

        return Ok(productoDto);
    }

    [HttpGet("buscar")]
    public async Task<IActionResult> BuscarPorNombre([FromQuery] string nombre)
    {
        var productos = await _productoService.BuscarPorNombre(nombre);

        var productosDto = productos
            .Select(ProductoMapper.ToDto);

        return Ok(productosDto);
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerProductos(
    [FromQuery] FiltrosProductoDto filtros)
    {
        var productos = await _productoService.Filtrar(filtros);

        return Ok(productos.Select(ProductoMapper.ToDto));
    }

    [HttpPost]
    public async Task<IActionResult> CrearProducto([FromBody] CrearProductoDto dto)
    {
        var producto = ProductoMapper.ToEntity(dto);

        await _productoService.GuardarProducto(producto);

        return CreatedAtAction(
            nameof(ObtenerPorId),
            new { id = producto.Id },
            ProductoMapper.ToDto(producto)
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarProducto(int id)
    {
        await _productoService.EliminarProducto(id);

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarProducto(
    int id,
    [FromBody] ActualizarProductoDto dto)
    {
        var producto = ProductoMapper.ToEntity(dto);

        await _productoService.ActualizarProducto(id, producto);

        return NoContent();
    }
}