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
    public partial class FormListarVenta : Form
    {
        public FormListarVenta()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormListarVenta_Load(object sender, EventArgs e)
        {
            ClassVistas lg = new ClassVistas();
            {
                this.dataGridView1.DataSource = lg.ListarVistaVenta();
                this.dataGridView1.Refresh();
            }
            this.dataGridView1.Columns["id_producto"].Visible = false;
            this.dataGridView1.Columns["id_cliente"].Visible = false;
        }


    

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormIngresarVenta form2 = new FormIngresarVenta();

            form2.FormClosed += new FormClosedEventHandler(form2_FormClosed);
            form2.ShowDialog();
        }




        private void form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClassVistas lg = new ClassVistas();
            {
                this.dataGridView1.DataSource = lg.ListarVistaVenta();
                this.dataGridView1.Refresh();
            }
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
                    this.dataGridView1.DataSource = lg.ListarVistaVenta();
                    this.dataGridView1.Refresh();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FormActualizarVenta frm = new FormActualizarVenta();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                frm.textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                frm.dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                frm.textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                frm.textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                frm.textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                frm.label8.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                frm.label9.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                frm.label6.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                frm.label10.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();


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
                    ClassVenta lgTipo = new ClassVenta();
                    resp = lgTipo.EliminarVenta(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                    MessageBox.Show(resp);

                    ClassVistas lg = new ClassVistas();
                    {
                        this.dataGridView1.DataSource = lg.ListarVistaVenta();
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
