using Backend.Models;
namespace Backend.Interfaces;

public interface IProductoService
{
    List<Producto> MostrarTodo();
    void GuardarProducto(Producto producto);
    void EliminarProducto(int id);
    void ActualizarProducto(int id, Producto productoActualizado);
}