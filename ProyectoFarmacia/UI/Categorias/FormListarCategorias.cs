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
    public partial class FormListarCategorias : Form
    {
        public FormListarCategorias()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormListarCategorias_Load(object sender, EventArgs e)
        {
            ClassCategoria lg = new ClassCategoria();
            {
                this.dataGridView1.DataSource = lg.ListarCategoria();
                this.dataGridView1.Refresh();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Categorias.FormIngresarCategoria form2 = new Categorias.FormIngresarCategoria();

            form2.FormClosed += new FormClosedEventHandler(form2_FormClosed);
            form2.ShowDialog();
        }


        private void form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClassCategoria lg = new ClassCategoria();
            {
                this.dataGridView1.DataSource = lg.ListarCategoria();
                this.dataGridView1.Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Eliminar?", "Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string resp = "";
                    ClassCategoria lgTipo = new ClassCategoria();
                    resp = lgTipo.EliminarCategoria(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                    MessageBox.Show(resp);

                    ClassCategoria lg = new ClassCategoria();
                    {
                        this.dataGridView1.DataSource = lg.ListarCategoria();
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
                ClassCategoria lg = new ClassCategoria();
                {
                    this.dataGridView1.DataSource = lg.ListarCategoria();
                    this.dataGridView1.Refresh();
                }
            }
        }
    }
}
