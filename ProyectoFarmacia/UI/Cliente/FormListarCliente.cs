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
    public partial class FormListarCliente : Form
    {
        public FormListarCliente()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormListarCliente_Load(object sender, EventArgs e)
        {
            ClassCliente lg = new ClassCliente();
            {
                this.dataGridView1.DataSource = lg.ListarCliente();
                this.dataGridView1.Refresh();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Cliente.FormIngresarCliente form2 = new Cliente.FormIngresarCliente();

            form2.FormClosed += new FormClosedEventHandler(form2_FormClosed);
            form2.ShowDialog();
        }



        private void form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClassCliente lg = new ClassCliente();
            {
                this.dataGridView1.DataSource = lg.ListarCliente();
                this.dataGridView1.Refresh();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FormActualizarCliente frm = new FormActualizarCliente();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                frm.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                frm.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                frm.textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                frm.textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                frm.textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

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
                    ClassCliente lgTipo = new ClassCliente();
                    resp = lgTipo.EliminarCliente(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                    MessageBox.Show(resp);

                    ClassCliente lg = new ClassCliente();
                    {
                        this.dataGridView1.DataSource = lg.ListarCliente();
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
                ClassCliente lg = new ClassCliente();
                {
                    this.dataGridView1.DataSource = lg.ListarCliente();
                    this.dataGridView1.Refresh();
                }
            }
        }
    }
}
