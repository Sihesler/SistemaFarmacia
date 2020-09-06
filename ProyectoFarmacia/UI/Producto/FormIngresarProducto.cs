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
    public partial class FormIngresarProducto : Form
    {
        public FormIngresarProducto()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormIngresarProducto_Load(object sender, EventArgs e)
        {
            ClassCategoria categoria = new ClassCategoria();
            this.comboBox1.DataSource = categoria.ListarCategoria();
            this.comboBox1.DisplayMember = "nombre";
            this.comboBox1.ValueMember = "id_categoria";
            this.comboBox1.Refresh();

            checkBox1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                string resp = "";
                ClassProducto producto = new ClassProducto();
                resp = producto.IngresarProducto(textBox1.Text, textBox2.Text, textBox3.Text, Convert.ToInt32(textBox4.Text), richTextBox1.Text, 
                       dateTimePicker1.Value, checkBox1.Checked, Convert.ToInt32(comboBox1.SelectedValue));
                MessageBox.Show(resp);


                if (resp == "El Producto se Registró con éxito.")

                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    richTextBox1.Text = "";
                    dateTimePicker1.Value = DateTime.Now;
                    checkBox1.Checked = false;
                    textBox1.Focus();
                }
                else if (resp == "ALERTA, El código de barra ya existe.")
                {

                }


            }
            else
            {
                MessageBox.Show("Error,complete los campos");
            }
        }
    }
}
