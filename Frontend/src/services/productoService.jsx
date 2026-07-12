import axios from "axios";

const API = "http://localhost:5168/api/Producto";

async function obtenerProductos() {

    const respuesta = await axios.get(API);

    return respuesta.data;
}

async function guardarProducto(producto) {

    await axios.post(API, producto);
}

export default {
    obtenerProductos,
    guardarProducto
};