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
    public partial class FormIngresarVenta : Form
    {
        int verificar;
        public FormIngresarVenta()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            verificar = 1;
            FormBuscarCliente frm = new FormBuscarCliente(verificar);
            AddOwnedForm(frm);
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            verificar = 1;
            FormBuscarProducto frm = new FormBuscarProducto(verificar);
            AddOwnedForm(frm);
            frm.Show();
        }



        public void button4_Click(object sender, EventArgs e)
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

        private void FormIngresarVenta_Load(object sender, EventArgs e)
        {
            //this.label8.Text = "5.2";
            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && label9.Text != "")
            { 
                string resp = "";
            
                ClassVenta venta = new ClassVenta();
                int cantidad = Convert.ToInt32(textBox3.Text);
                decimal total = Convert.ToDecimal(label9.Text);
                int cliente = Convert.ToInt32(label10.Text);
                int producto = Convert.ToInt32(label6.Text);
            
                resp = venta.IngresarVenta(dateTimePicker1.Value, cantidad, total, producto, cliente);
                MessageBox.Show(resp);


                if (resp == "La Venta se Registró con éxito.")

                {
                    //limpiar textbox
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    label7.Text = "";
                    textBox1.Focus();
                }
            }
            else
            {
                MessageBox.Show("Complete los campos.");
            }
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
