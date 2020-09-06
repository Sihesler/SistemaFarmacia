using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataSetFarmaciaTableAdapters;

namespace BLL
{
    public class ClassVenta
    {
        //atributos
        private VentaTableAdapter ingresarventa;
        private VentaTableAdapter actualizarventa;
        private VentaTableAdapter eliminarventa;


        //propiedades
        private VentaTableAdapter INGRESARVENTA
        {
            get
            {
                if (ingresarventa == null)
                {
                    ingresarventa = new VentaTableAdapter();
                }
                return ingresarventa;
            }
        }

        private VentaTableAdapter ACTUALIZARVENTA
        {
            get
            {
                if (actualizarventa == null)
                {
                    actualizarventa = new VentaTableAdapter();
                }
                return actualizarventa;
            }
        }

        private VentaTableAdapter ELIMINARVENTA
        {
            get
            {
                if (eliminarventa == null)
                {
                    eliminarventa = new VentaTableAdapter();
                }
                return eliminarventa;
            }
        }


        //metodos
        public string IngresarVenta(DateTime fecha, int cantidad, decimal total, int producto, int cliente)
        {
            string resultado = "";
            INGRESARVENTA.sp_ingresar_venta(fecha, cantidad, total, producto, cliente, ref resultado);

            return resultado ;

        }


        public string ActualizarVenta(int codigo, DateTime fecha, int cantidad, decimal total, int producto, int cliente)
        {
            string resultado = "";
            ACTUALIZARVENTA.sp_actualizar_Venta(codigo, fecha, cantidad, total, producto, cliente, ref resultado);

            return resultado;

        }

        public string EliminarVenta(int codigo)
        {
            string resultado = "";
            ELIMINARVENTA.sp_eliminar_venta(codigo, ref resultado);

            return resultado;

        }


    }
}
