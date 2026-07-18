using Backend.Models;
using Backend.DTOs;

namespace Backend.Interfaces;

public interface IProductoService
{
    Task<List<Producto>> MostrarTodo();
    Task<List<Producto>> Filtrar(FiltrosProductoDto filtros);

    Task<Producto> ObtenerPorId(int id);

    Task<List<Producto>> BuscarPorNombre(string nombre);

    Task GuardarProducto(Producto producto);

    Task ActualizarProducto(int id, Producto producto);

    Task EliminarProducto(int id);
}