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

namespace UI.Venta
{
    public partial class FormActualizarVenta : Form
    {
        int verificar = 0;

        public FormActualizarVenta()
        {
            InitializeComponent();
        }

        private void FormActualizarVenta_Load(object sender, EventArgs e)
        {
            this.textBox1.Enabled = false;
            this.textBox2.Enabled = false;
            this.textBox4.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            verificar = 2;
            FormBuscarCliente frm = new FormBuscarCliente(verificar);
            AddOwnedForm(frm);
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            verificar = 2;
            FormBuscarProducto frm = new FormBuscarProducto(verificar);
            AddOwnedForm(frm);
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                decimal total = 0;
                int cantidad = Convert.ToInt32(textBox3.Text);
                decimal precio = Convert.ToDecimal(label8.Text);

                total = cantidad * precio;

                label9.Text = total.ToString();
            }
            else
            {
                MessageBox.Show("Agregue la cantidad del producto");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string resp = "";
            ClassVenta venta = new ClassVenta();

            int codigo = Convert.ToInt32(textBox4.Text);
            int cliente = Convert.ToInt32(label10.Text);
            int producto = Convert.ToInt32(label6.Text);
            int cantidad = Convert.ToInt32(textBox3.Text);
            decimal total = Convert.ToDecimal(label9.Text);

            resp = venta.ActualizarVenta(codigo, dateTimePicker1.Value, cantidad, total, producto, cliente);
            MessageBox.Show(resp);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "[^0-9]"))
            {
                MessageBox.Show("Ingrese solo números");
                textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
            }
        }
    }
}
