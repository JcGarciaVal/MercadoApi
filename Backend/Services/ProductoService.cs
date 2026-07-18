using Backend.Data;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Backend.Exceptions;
using Backend.DTOs;

namespace Backend.Services;

public class ProductoService : IProductoService
{
    private readonly AppDbContext _context;


    public ProductoService(AppDbContext context)
    {
        _context = context;
    }


    public async Task<List<Producto>> MostrarTodo()
    {
        return await _context.Productos.ToListAsync();
    }

    public async Task<Producto> ObtenerPorId(int id)
    {
        var producto = await _context.Productos
            .FirstOrDefaultAsync(p => p.Id == id);

        if (producto == null)
            throw new ProductoNoEncontradoException(id);

        return producto;
    }

    public async Task<List<Producto>> BuscarPorNombre(string nombre)
    {
        return await _context.Productos
            .Where(p => p.Nombre.Contains(nombre))
            .ToListAsync();
    }


    public async Task GuardarProducto(Producto producto)
    {
        _context.Productos.Add(producto);

        await _context.SaveChangesAsync();
    }


    public async Task EliminarProducto(int id)
    {
        var producto = await _context.Productos
            .FirstOrDefaultAsync(p => p.Id == id);

        if (producto == null)
            throw new ProductoNoEncontradoException(id);

        _context.Productos.Remove(producto);

        await _context.SaveChangesAsync();
    }


    public async Task ActualizarProducto(int id, Producto productoActualizado)
    {
        var producto = await _context.Productos
            .FirstOrDefaultAsync(p => p.Id == id);

        if (producto == null)
            throw new ProductoNoEncontradoException(id);

        producto.Nombre = productoActualizado.Nombre;
        producto.Precio = productoActualizado.Precio;
        producto.Stock = productoActualizado.Stock;

        await _context.SaveChangesAsync();
    }

    public async Task<List<Producto>> Filtrar(FiltrosProductoDto filtros)
    {
        var query = _context.Productos.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filtros.Nombre))
        {
            query = query.Where(p =>
                p.Nombre.Contains(filtros.Nombre));
        }

        if (filtros.PrecioMin.HasValue)
        {
            query = query.Where(p =>
                p.Precio >= filtros.PrecioMin.Value);
        }

        if (filtros.PrecioMax.HasValue)
        {
            query = query.Where(p =>
                p.Precio <= filtros.PrecioMax.Value);
        }

        if (filtros.StockMin.HasValue)
        {
            query = query.Where(p =>
                p.Stock >= filtros.StockMin.Value);
        }

        if (filtros.StockMax.HasValue)
        {
            query = query.Where(p =>
                p.Stock <= filtros.StockMax.Value);
        }

        query = query
            .Skip((filtros.Page - 1) * filtros.PageSize)
            .Take(filtros.PageSize);

        return await query.ToListAsync();
    }
}