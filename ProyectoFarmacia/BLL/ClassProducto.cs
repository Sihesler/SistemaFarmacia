using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using DAL.DataSetFarmaciaTableAdapters;

namespace BLL
{
    public class ClassProducto
    {
        //atributos
        private ProductoTableAdapter listarproducto;
        private ProductoTableAdapter ingresarproducto;
        private ProductoTableAdapter actualizarproducto;
        private ProductoTableAdapter eliminarproducto;


        //propiedades
        private ProductoTableAdapter LISTARPRODUCTO
        {
            get
            {
                if (listarproducto == null)
                {
                    listarproducto = new ProductoTableAdapter();
                }
                return listarproducto;
            }
        }

        private ProductoTableAdapter INGRESARPRODUCTO
        {
            get
            {
                if (ingresarproducto == null)
                {
                    ingresarproducto = new ProductoTableAdapter();
                }
                return ingresarproducto;
            }
        }

        private ProductoTableAdapter ACTUALIZARPRODUCTO
        {
            get
            {
                if (actualizarproducto == null)
                {
                    actualizarproducto = new ProductoTableAdapter();
                }
                return actualizarproducto;
            }
        }

        private ProductoTableAdapter ELIMINARPRODUCTO
        {
            get
            {
                if (eliminarproducto == null)
                {
                    eliminarproducto = new ProductoTableAdapter();
                }
                return eliminarproducto;
            }
        }

        //metodos

        //----- INGRESAR -----
        public string IngresarProducto(string barra, string nombre, string precio, int existencia, string descripcion, DateTime caducidad, bool estado, int categoria)
        {
            string resultado = "";
            INGRESARPRODUCTO.sp_ingresar_producto(barra, nombre, precio, existencia, descripcion, caducidad, estado, categoria, ref resultado);

            return resultado;

        }

        public string ActualizarProducto(int codigo, string barra, string nombre, double precio, int existencia, string descripcion, DateTime caducidad, Boolean estado, int categoria)
        {
            string resultado = "";
            ACTUALIZARPRODUCTO.sp_actualizar_Producto(codigo, barra, nombre, precio, existencia, descripcion, caducidad, estado, categoria, ref resultado);

            return resultado;

        }

        public string EliminarProducto(int codigo)
        {
            string resultado = "";
            ELIMINARPRODUCTO.sp_eliminar_producto(codigo, ref resultado);

            return resultado;

        }

        //----- LISTAR -----
        public DataTable ListarProducto()
        {
            return LISTARPRODUCTO.GetDataListarProducto();
        }
    }
}
