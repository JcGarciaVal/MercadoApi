using Backend.Interfaces;
using Backend.Models;
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

    [HttpGet]
    public IActionResult GetAll()
    {
        var productos = _productoService.MostrarTodo();

        var productosDto = productos
            .Select(ProductoMapper.ToDto);

        return Ok(productosDto);
    }

    [HttpPost]
    public IActionResult CrearProducto([FromBody] CrearProductoDto dto)
    {
        var producto = ProductoMapper.ToEntity(dto);
        _productoService.GuardarProducto(producto);

        return Created();
    }

    [HttpDelete("{id}")]
    public IActionResult EliminarProducto(int id)
    {
        _productoService.EliminarProducto(id);

        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult ActualizarProducto(
    int id,
    [FromBody] ActualizarProductoDto dto)
    {
        var producto = ProductoMapper.ToEntity(dto);

        _productoService.ActualizarProducto(id, producto);

        return NoContent();
    }
}