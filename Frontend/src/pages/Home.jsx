import { useEffect, useState } from "react";
import productoService from "../services/productoService";
import ProductoForm from "../contents/ProductoForm";
import ProductoList from "../contents/ProductoList";

function Home() {

    const [productos, setProductos] = useState([]);

    async function obtenerProductos() {

        try {

            const productos = await productoService.obtenerProductos();

            setProductos(productos);

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
            />

            <hr />

            <ProductoList
                productos={productos}
            />
        </>
    );
}

export default Home;