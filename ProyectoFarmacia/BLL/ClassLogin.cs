using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using DAL.DataSetFarmaciaTableAdapters;

namespace BLL
{
    public class ClassLogin
    {
        //atributos
        private LoginTableAdapter logeo;
        private LoginTableAdapter listarlogin;


        //propiedades
        private LoginTableAdapter LISTARLOGIN
        {
            get
            {
                if (listarlogin == null)
                {
                    listarlogin = new LoginTableAdapter();
                }
                return listarlogin;
            }
        }

        private LoginTableAdapter LOGUEO
        {
            get
            {
                if (logeo == null)
                {
                    logeo = new LoginTableAdapter();
                }
                return logeo;
            }
        }


        //metodos

        public string Loguearse(string user, string pass)
        {
            string resultado = "";
            DataTable tabla = new DataTable();
            tabla = LOGUEO.GetDataLogueo(user, pass, ref resultado);
            return resultado;
        }


        //----- LISTAR -----
        public DataTable ListarLogin()
        {

            return LISTARLOGIN.GetDataListarLogin();
        }

    }
}
