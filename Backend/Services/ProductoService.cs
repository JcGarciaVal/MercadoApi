using Backend.Data;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Services;

public class ProductoService : IProductoService
{
    private readonly AppDbContext _context;


    public ProductoService(AppDbContext context)
    {
        _context = context;
    }


    public List<Producto> MostrarTodo()
    {
        return _context.Productos.ToList();
    }


    public void GuardarProducto(Producto producto)
    {
        _context.Productos.Add(producto);

        _context.SaveChanges();
    }


    public void EliminarProducto(int id)
    {
        var producto = _context.Productos
            .FirstOrDefault(p => p.Id == id);


        if (producto == null)
            throw new Exception("Producto no encontrado");


        _context.Productos.Remove(producto);

        _context.SaveChanges();
    }


    public void ActualizarProducto(int id, Producto productoActualizado)
    {
        var producto = _context.Productos
            .FirstOrDefault(p => p.Id == id);


        if (producto == null)
            throw new Exception("Producto no encontrado");


        producto.Nombre = productoActualizado.Nombre;
        producto.Precio = productoActualizado.Precio;
        producto.Stock = productoActualizado.Stock;


        _context.SaveChanges();
    }
}