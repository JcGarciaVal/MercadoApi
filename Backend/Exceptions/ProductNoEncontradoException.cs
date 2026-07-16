namespace Backend.Exceptions;

public class ProductoNoEncontradoException : Exception
{
    public ProductoNoEncontradoException(int id)
        : base($"No existe un producto con el id {id}.")
    {
    }

    public ProductoNoEncontradoException(string mensaje)
        : base(mensaje)
    {
    }
}