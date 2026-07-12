using Backend.Models;

namespace Backend.Interfaces;

public interface IProductoJson
{
    List<Producto> EntregarDatosJson();

    void GuardarDatosJson(List<Producto> productos);

}