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

namespace UI.Producto
{
    public partial class FormActualizarProducto : Form
    {
        int verificar;

        public FormActualizarProducto()
        {
            InitializeComponent();
        }

        private void FormActualizarProducto_Load(object sender, EventArgs e)
        {
            label10.Visible = false;

            textBox1.Enabled = false;
            textBox6.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            verificar = 1;
            FormBuscarProducto frm = new FormBuscarProducto(verificar);
            AddOwnedForm(frm);
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string resp = "";
            ClassProducto producto = new ClassProducto();
            resp = producto.ActualizarProducto(Convert.ToInt32(textBox1.Text.ToString()), textBox2.Text.ToString(),
                    textBox3.Text.ToString(), Convert.ToDouble(textBox4.Text.ToString()), Convert.ToInt32(textBox5.Text.ToString()),
                    richTextBox1.Text.ToString(), dateTimePicker1.Value, checkBox1.Checked, Convert.ToInt16(label10.Text));
            MessageBox.Show(resp);

            
        }

        

        private void textBox4_Leave(object sender, EventArgs e)
        {
            double res = Convert.ToDouble(textBox4.Text, System.Globalization.CultureInfo.InvariantCulture);
            textBox4.Text = string.Format("{0:f2}", res);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int total = 0;

            int v1 = Convert.ToInt32(textBox5.Text);
            int v2 = Convert.ToInt32(textBox7.Text);

            total = v1 + v2;
            this.textBox5.Text = total.ToString();
        }
    }
}
