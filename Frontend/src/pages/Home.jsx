import { useEffect, useState } from "react";
import productoService from "../services/productoService";
import ProductoForm from "../contents/ProductoForm";
import ProductoList from "../contents/ProductoList";

function Home() {

    const [productos, setProductos] = useState([]);
    const [productoEditar, setProductoEditar] = useState(null);

    async function obtenerProductos() {

        try {

            const productos = await productoService.obtenerProductos();

            setProductos(productos);

        } catch (error) {
            console.error(error);
        }
    }

    function seleccionarProducto(producto) {
    setProductoEditar(producto);
    }

    async function eliminarProducto(id) {

    const confirmar = window.confirm(
        "¿Estás seguro de que deseas eliminar este producto?"
    );

    if (!confirmar) {
        return;
    }

    try {

        await productoService.eliminarProducto(id);

        obtenerProductos();

    } catch (error) {
        console.error(error);
    }
}

    useEffect(() => {
        obtenerProductos();
    }, []);

    return (
        <>
            <ProductoForm
                obtenerProductos={obtenerProductos}
                productoEditar={productoEditar}
                setProductoEditar={setProductoEditar}
            />

            <hr />

            <ProductoList
                productos={productos}
                eliminarProducto={eliminarProducto}
                seleccionarProducto={seleccionarProducto}
            />
        </>
    );
}

export default Home;