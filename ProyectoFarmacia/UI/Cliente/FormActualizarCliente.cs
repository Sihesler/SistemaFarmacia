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
    public partial class FormActualizarCliente : Form
    {
        public FormActualizarCliente()
        {
            InitializeComponent();
        }

        private void FormActualizarCliente_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                string resp = "";
                ClassCliente cliente = new ClassCliente();
                resp = cliente.ActualizarCliente(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
                MessageBox.Show(resp);
            }
            else
            {
                MessageBox.Show("Error complete los campos");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, "[^0-9]"))
            {
                MessageBox.Show("Ingreso sólo números");
                textBox5.Text = textBox5.Text.Remove(textBox5.Text.Length - 1);
            }
        }
    }
}
