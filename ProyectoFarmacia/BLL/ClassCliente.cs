using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using DAL.DataSetFarmaciaTableAdapters;

namespace BLL
{
    public class ClassCliente
    {
        //atributos
        private ClienteTableAdapter listarcliente;
        private ClienteTableAdapter ingresarcliente;
        private ClienteTableAdapter actualizarcliente;
        private ClienteTableAdapter eliminarcliente;


        //propiedades
        private ClienteTableAdapter LISTARCLIENTE
        {
            get
            {
                if (listarcliente == null)
                {
                    listarcliente = new ClienteTableAdapter();
                }
                return listarcliente;
            }
        }

        private ClienteTableAdapter INGRESARCLIENTE
        {
            get
            {
                if (ingresarcliente == null)
                {
                    ingresarcliente = new ClienteTableAdapter();
                }
                return ingresarcliente;
            }
        }

        private ClienteTableAdapter ACTUALIZARCLIENTE
        {
            get
            {
                if (actualizarcliente == null)
                {
                    actualizarcliente = new ClienteTableAdapter();
                }
                return actualizarcliente;
            }
        }

        private ClienteTableAdapter ELIMINARCLIENTE
        {
            get
            {
                if (eliminarcliente == null)
                {
                    eliminarcliente = new ClienteTableAdapter();
                }
                return eliminarcliente;
            }
        }


        //metodos

        //----- INGRESAR -----
        public string IngresarCliente(string nit, string nombre, string apellido, string telefono)
        {
            string resultado = "";
            INGRESARCLIENTE.sp_ingresarcliente(nit, nombre, apellido, telefono, ref resultado);

            return resultado;

        }

        public string ActualizarCliente(int codigo, string nit, string nombre, string apellido, string telefono)
        {
            string resultado = "";
            ACTUALIZARCLIENTE.sp_actualizar_cliente(codigo, nit, nombre, apellido, telefono, ref resultado);

            return resultado;

        }

        public string EliminarCliente(int codigo)
        {
            string resultado = "";
            ELIMINARCLIENTE.sp_eliminar_cliente(codigo, ref resultado);

            return resultado;

        }

        //----- LISTAR -----
        public DataTable ListarCliente()
        {

            return LISTARCLIENTE.GetDataListarCliente();
        }


    }
}
