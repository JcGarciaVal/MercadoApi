import axios from "axios";

const API = "http://localhost:5168/api/Producto";

async function obtenerProductos() {

    const respuesta = await axios.get(API);

    return respuesta.data;
}

async function guardarProducto(producto) {

    await axios.post(API, producto);
}

async function eliminarProducto(id) {
    await axios.delete(`${API}/${id}`);
}

async function actualizarProducto(id, producto) {
    await axios.put(`${API}/${id}`, producto);
}

export default {
    obtenerProductos,
    guardarProducto,
    eliminarProducto,
    actualizarProducto
};