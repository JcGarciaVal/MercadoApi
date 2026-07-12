using Backend.Data;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Services;

public class ProductoService : IProductoService
{
    private readonly IProductoJson _productosJson;

    public ProductoService(IProductoJson productosJson)
    {
        _productosJson = productosJson;
    }
    public List<Producto> MostrarTodo()
    {
        return _productosJson.EntregarDatosJson();
    }

    public void GuardarProducto(Producto producto)
    {
        var lista = _productosJson.EntregarDatosJson();

        producto.Id = lista.Any()
            ? lista.Max(p => p.Id) + 1
            : 1;

        lista.Add(producto);

        _productosJson.GuardarDatosJson(lista);
    }

    public void EliminarProducto(int id)
    {
        var lista = _productosJson.EntregarDatosJson();

        var producto = lista.FirstOrDefault(p =>
            p.Id == id);

        if (producto == null)
            throw new Exception("Producto no encotrado.");

        lista.Remove(producto);

        _productosJson.GuardarDatosJson(lista);
    }

    public bool ActualizarProducto(int id, Producto productoActualizado)
    {
        var lista = _productosJson.EntregarDatosJson();

        var producto = lista.FirstOrDefault(p => p.Id == id);

        if (producto == null)
            return false;

        producto.Nombre = productoActualizado.Nombre;
        producto.Precio = productoActualizado.Precio;
        producto.Stock = productoActualizado.Stock;

        _productosJson.GuardarDatosJson(lista);

        return true;
    }
}