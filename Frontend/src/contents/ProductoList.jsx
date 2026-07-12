function ProductoList({ productos, eliminarProducto, seleccionarProducto }) {
    return (
        <>
            <h2>Listado de Productos</h2>

            <table border="1" cellPadding="10">

                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Nombre</th>
                        <th>Precio</th>
                        <th>Stock</th>
                        <th>Acciones</th>
                    </tr>
                </thead>

                <tbody>

                    {productos.map((producto) => (

                        <tr key={producto.id}>
                            <td>{producto.id}</td>
                            <td>{producto.nombre}</td>
                            <td>{producto.precio}</td>
                            <td>{producto.stock}</td>
                            <td>
                                <button
                                    onClick={() => seleccionarProducto(producto)}
                                >
                                    Editar
                                </button>
                                <button
                                    onClick={() => eliminarProducto(producto.id)}
                                >
                                    Eliminar
                                </button>
                            </td>
                        </tr>
                    ))}

                </tbody>

            </table>
        </>
    );
}

export default ProductoList;