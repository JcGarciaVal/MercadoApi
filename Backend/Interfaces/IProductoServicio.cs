using Backend.Models;
namespace Backend.Interfaces;

public interface IProductoService
{
    Task<List<Producto>> MostrarTodo();

    Task<Producto> ObtenerPorId(int id);

    Task GuardarProducto(Producto producto);

    Task ActualizarProducto(int id, Producto producto);

    Task EliminarProducto(int id);
}