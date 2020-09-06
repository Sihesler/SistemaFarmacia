using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using DAL.DataSetFarmaciaTableAdapters;

namespace BLL
{
    public class ClassCategoria
    {
        //atributos
        private CategoriaTableAdapter listarcategoria;
        private CategoriaTableAdapter ingresarcategoria;
        private CategoriaTableAdapter eliminarcategoria;


        //propiedades
        private CategoriaTableAdapter LISTARCATEGORIA
        {
            get
            {
                if (listarcategoria == null)
                {
                    listarcategoria = new CategoriaTableAdapter();
                }
                return listarcategoria;
            }
        }

        private CategoriaTableAdapter INGRESARCATEGORIA
        {
            get
            {
                if (ingresarcategoria == null)
                {
                    ingresarcategoria = new CategoriaTableAdapter();
                }
                return ingresarcategoria;
            }
        }

        private CategoriaTableAdapter ELIMINARCATEGORIA
        {
            get
            {
                if (eliminarcategoria == null)
                {
                    eliminarcategoria = new CategoriaTableAdapter();
                }
                return eliminarcategoria;
            }
        }


        //metodos

        //----- INGRESAR -----
        public string IngresarCategoria(string nombre)
        {
            string resultado = "";
            INGRESARCATEGORIA.sp_ingresar_categoria(nombre, ref resultado);

            return resultado;

        }

        //public string ActualizarCliente(int codigo, string nit, string nombre, string apellido, string telefono)
        //{
        //    string resultado = "";
        //    ACTUALIZARCLIENTE.sp_actualizar_cliente(codigo, nit, nombre, apellido, telefono, ref resultado);

        //    return resultado;

        //}

        public string EliminarCategoria(int codigo)
        {
            string resultado = "";
            ELIMINARCATEGORIA.sp_eliminar_categoria(codigo, ref resultado);

            return resultado;

        }

        //----- LISTAR -----
        public DataTable ListarCategoria()
        {
            return LISTARCATEGORIA.GetDataListarCategoria();
        }
    }
}
