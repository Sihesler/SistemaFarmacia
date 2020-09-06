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
    public partial class FormBuscarProducto : Form
    {
        public int validar;
        public FormBuscarProducto(int variable)
        {
            InitializeComponent();
            this.validar = variable;
        }

        private void FormBuscarProducto_Load(object sender, EventArgs e)
        {
            ClassVistas lg = new ClassVistas();
            {
                this.dataGridView1.DataSource = lg.ListarVistaProductoDisponible();
                this.dataGridView1.Refresh();
            }
            //this.dataGridView1.Columns["id_categoria"].Visible = false;
            label1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                dataGridView1.CurrentCell = null;
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    r.Visible = false;
                }

                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell c in r.Cells)
                    {
                        if ((c.Value.ToString().ToUpper()).IndexOf(textBox1.Text.ToUpper()) == 0)
                        {
                            r.Visible = true;
                            break;

                        }
                    }
                }
            }
            else
            {
                ClassVistas lg = new ClassVistas();
                {
                    this.dataGridView1.DataSource = lg.ListarVistaProducto();
                    this.dataGridView1.Refresh();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validar == 1)
            {
                FormIngresarVenta frm = Owner as FormIngresarVenta;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    frm.label6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    frm.textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    frm.label8.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

                    this.Close();
                }
                else
                    MessageBox.Show("Debe seleccionar una fila");
            }


            if (validar == 2)
            {
                FormActualizarVenta frm = Owner as FormActualizarVenta;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    frm.label6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    frm.textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    frm.label8.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

                    this.Close();
                }
                else
                    MessageBox.Show("Debe seleccionar una fila");
            }

        }
    }
}
