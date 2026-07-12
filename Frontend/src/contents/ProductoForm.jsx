import { useEffect, useState } from "react";
import productoService from "../services/productoService";


function ProductoForm({ 
    obtenerProductos,
    productoEditar,
    setProductoEditar
}) {

    const [id, setId] = useState(null);

    const [nombre, setNombre] = useState("");
    const [precio, setPrecio] = useState("");
    const [stock, setStock] = useState("");


    useEffect(() => {

        if(productoEditar){

            setId(productoEditar.id);
            setNombre(productoEditar.nombre);
            setPrecio(productoEditar.precio);
            setStock(productoEditar.stock);

        }

    }, [productoEditar]);


    async function guardarProducto(e){

        e.preventDefault();


        const producto = {
            nombre,
            precio: Number(precio),
            stock: Number(stock)
        };


        try {

            if(id){

                await productoService.actualizarProducto(
                    id,
                    producto
                );

                alert("Producto actualizado correctamente");


            }else{

                await productoService.guardarProducto(producto);

                alert("Producto creado correctamente");

            }


            limpiarFormulario();

            obtenerProductos();


        } catch(error){

            console.error(error);

        }

    }


    function limpiarFormulario(){

        setId(null);
        setNombre("");
        setPrecio("");
        setStock("");

        setProductoEditar(null);
    }


    return (

        <form onSubmit={guardarProducto}>

            <h2>
                {id ? "Editar Producto" : "Nuevo Producto"}
            </h2>


            <div>

                <label>
                    Nombre
                </label>

                <br />

                <input
                    type="text"
                    value={nombre}
                    onChange={(e)=>setNombre(e.target.value)}
                />

            </div>


            <br />


            <div>

                <label>
                    Precio
                </label>

                <br />

                <input
                    type="number"
                    value={precio}
                    onChange={(e)=>setPrecio(e.target.value)}
                />

            </div>


            <br />


            <div>

                <label>
                    Stock
                </label>

                <br />

                <input
                    type="number"
                    value={stock}
                    onChange={(e)=>setStock(e.target.value)}
                />

            </div>


            <br />


            <button type="submit">

                {id ? "Actualizar" : "Guardar"}

            </button>


            {
                id &&

                <button
                    type="button"
                    onClick={limpiarFormulario}
                >
                    Cancelar
                </button>
            }


        </form>

    );
}


export default ProductoForm;