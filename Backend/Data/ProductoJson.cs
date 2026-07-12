using System.Text.Json;
using Backend.Models;
using Backend.Interfaces;

namespace Backend.Data;

public class ProductoJson : IProductoJson
{
    private readonly string _ruta = Path.Combine("Data", "productos.json");

    public List<Producto> EntregarDatosJson()
    {
        if (!File.Exists(_ruta))
            throw new Exception("Archivo no encontrado");

        var json = File.ReadAllText(_ruta);

        if (string.IsNullOrWhiteSpace(json))
            return new List<Producto>();

        return JsonSerializer.Deserialize<List<Producto>>(json)
            ?? new List<Producto>();
    }

    public void GuardarDatosJson(List<Producto> productos)
    {
        var opciones = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        var json = JsonSerializer.Serialize(productos, opciones);

        File.WriteAllText(_ruta, json);
    }
}