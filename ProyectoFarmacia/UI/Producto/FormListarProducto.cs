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
    public partial class FormListarProducto : Form
    {
        public FormListarProducto()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormListarProducto_Load(object sender, EventArgs e)
        {
            ClassVistas lg = new ClassVistas();
            {
                this.dataGridView1.DataSource = lg.ListarVistaProducto();
                this.dataGridView1.Refresh();
            }
            this.dataGridView1.Columns["id_categoria"].Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Producto.FormIngresarProducto form2 = new Producto.FormIngresarProducto();

            form2.FormClosed += new FormClosedEventHandler(form2_FormClosed);
            form2.ShowDialog();
        }

        private void form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClassVistas lg = new ClassVistas();
            {
                this.dataGridView1.DataSource = lg.ListarVistaProducto();
                this.dataGridView1.Refresh();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FormActualizarProducto frm = new FormActualizarProducto();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                frm.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                frm.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                frm.textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                frm.textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                frm.textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                frm.richTextBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                frm.dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[6].Value.ToString());
                frm.checkBox1.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[7].Value.ToString());
                frm.textBox6.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                frm.label10.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();

                frm.FormClosed += new FormClosedEventHandler(form2_FormClosed);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Debe seleccionar una fila");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Eliminar?", "Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string resp = "";
                    ClassProducto lgTipo = new ClassProducto();
                    resp = lgTipo.EliminarProducto(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                    MessageBox.Show(resp);

                    ClassVistas lg = new ClassVistas();
                    {
                        this.dataGridView1.DataSource = lg.ListarVistaProducto();
                        this.dataGridView1.Refresh();
                    }
                }
                else
                {
                    //tus codigos
                }

            }
            else
                MessageBox.Show("Debe seleccionar una fila");
        }
    }
}
