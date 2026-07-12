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
            throw new Exception("Producto no Existe");

        lista.Remove(producto);

        _productosJson.GuardarDatosJson(lista);
    }
}