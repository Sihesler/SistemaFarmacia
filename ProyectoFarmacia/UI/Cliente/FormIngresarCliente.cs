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

namespace UI.Cliente
{
    public partial class FormIngresarCliente : Form
    {
        public FormIngresarCliente()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                string resp = "";
                ClassCliente cliente = new ClassCliente();
                resp = cliente.IngresarCliente(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                MessageBox.Show(resp);


                if (resp == "El Cliente se Registró con éxito.")

                {
                    //limpiar textbox
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox1.Focus();
                }
                else if (resp == "ALERTA, el número de nit ya existe.")
                {

                }

            }
            else
            {
                MessageBox.Show("Error complete los campos");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nit = "C/F";
            this.textBox1.Text = nit;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "[^0-9]"))
            {
                MessageBox.Show("Ingreso sólo números");
                textBox4.Text = textBox4.Text.Remove(textBox4.Text.Length - 1);
            }
        }
    }
}
