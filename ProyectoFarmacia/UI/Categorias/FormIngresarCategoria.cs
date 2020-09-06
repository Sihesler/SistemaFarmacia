using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace UI.Categorias
{
    public partial class FormIngresarCategoria : Form
    {
        public FormIngresarCategoria()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string resp = "";
                ClassCategoria categoria = new ClassCategoria();
                resp = categoria.IngresarCategoria(textBox1.Text);
                MessageBox.Show(resp);


                if (resp == "La Categoría se Registró con éxito.")

                {
                    //limpiar textbox
                    textBox1.Text = "";
                    textBox1.Focus();
                }
            }
            else
            {
                MessageBox.Show("Error complete el campo.");
            }
        }
    }
}
