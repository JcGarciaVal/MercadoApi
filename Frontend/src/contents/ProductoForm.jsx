import { useState } from "react";
import productoService from "../services/productoService";

function ProductoForm({ obtenerProductos }) {

    const [nombre, setNombre] = useState("");
    const [precio, setPrecio] = useState("");
    const [stock, setStock] = useState("");

    const guardarProducto = async (e) => {
        e.preventDefault();

        const producto = {
            nombre,
            precio: Number(precio),
            stock: Number(stock)
        };

        try {

            await productoService.guardarProducto(producto);

            alert("Producto creado correctamente");

            setNombre("");
            setPrecio("");
            setStock("");

            obtenerProductos();

        } catch (error) {
            console.error(error);
        }
    };

    return (

        <form onSubmit={guardarProducto}>

            <h2>Nuevo Producto</h2>

            <div>
                <label>Nombre</label>
                <br />

                <input
                    type="text"
                    value={nombre}
                    onChange={(e) => setNombre(e.target.value)}
                />
            </div>

            <br />

            <div>
                <label>Precio</label>
                <br />

                <input
                    type="number"
                    value={precio}
                    onChange={(e) => setPrecio(e.target.value)}
                />
            </div>

            <br />

            <div>
                <label>Stock</label>
                <br />

                <input
                    type="number"
                    value={stock}
                    onChange={(e) => setStock(e.target.value)}
                />
            </div>

            <br />

            <button type="submit">
                Guardar
            </button>

        </form>

    );

}

export default ProductoForm;