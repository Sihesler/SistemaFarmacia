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

namespace UI.Usuarios
{
    public partial class FormListarUsuarios : Form
    {
        public FormListarUsuarios()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormListarUsuarios_Load(object sender, EventArgs e)
        {
            ClassLogin lg = new ClassLogin();
            {
                this.dataGridView1.DataSource = lg.ListarLogin();
                this.dataGridView1.Refresh();
            }
        }
    }
}
