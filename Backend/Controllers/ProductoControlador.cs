using Backend.Interfaces;
using Backend.Models;
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
        return Ok(_productoService.MostrarTodo());
    }

    [HttpPost]
    public IActionResult CrearProducto([FromBody] Producto producto)
    {
        _productoService.GuardarProducto(producto);
        Console.WriteLine(producto.Nombre);

        return CreatedAtAction(nameof(GetAll), producto);
    }

    [HttpDelete("{id}")]
    public IActionResult EliminarProducto(int id)
    {
        _productoService.EliminarProducto(id);

        return NoContent();
    }
}