using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using DAL.DataSetVistasTableAdapters;

namespace BLL
{
    public class ClassVistas
    {
        //atributos
        private VistaProductoTableAdapter vistaproducto;
        private VistaListarVentaTableAdapter vistaventa;
        private VistaProductosDisponiblesTableAdapter vistaproductodisponible;


        //propiedades
        private VistaProductoTableAdapter LISTARVISTAPRODUCTO
        {
            get
            {
                if (vistaproducto == null)
                {
                    vistaproducto = new VistaProductoTableAdapter();
                }
                return vistaproducto;
            }
        }

        private VistaListarVentaTableAdapter LISTARVISTAVENTA
        {
            get
            {
                if (vistaventa == null)
                {
                    vistaventa = new VistaListarVentaTableAdapter();
                }
                return vistaventa;
            }
        }

        private VistaProductosDisponiblesTableAdapter LISTARPRODUCTOSDISPONIBLES
        {
            get
            {
                if (vistaproductodisponible == null)
                {
                    vistaproductodisponible = new VistaProductosDisponiblesTableAdapter();
                }
                return vistaproductodisponible;
            }
        }


        //metodos
        public DataTable ListarVistaProducto()
        {

            return LISTARVISTAPRODUCTO.GetDataListarVistaProducto();
        }

        public DataTable ListarVistaVenta()
        {

            return LISTARVISTAVENTA.GetDataVistaVenta();
        }

        public DataTable ListarVistaProductoDisponible()
        {

            return LISTARPRODUCTOSDISPONIBLES.GetDataVistaProductoDisponibles();
        }
    }
}
