using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using BLL;

namespace UI
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void iconCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Titulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Titulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void textBoxUser_Enter(object sender, EventArgs e)
        {
            if(textBoxUser.Text == "Usuario")
            {
                textBoxUser.Text = "";

                textBoxUser.ForeColor = Color.Black;
            }
        }

        private void textBoxUser_Leave(object sender, EventArgs e)
        {
            if (textBoxUser.Text == "")
            {
                textBoxUser.Text = "Usuario";

                textBoxUser.ForeColor = Color.Silver;
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "Contraseña")
            {
                textBoxPassword.Text = "";

                textBoxPassword.ForeColor = Color.Black;
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "")
            {
                textBoxPassword.Text = "Contraseña";

                textBoxPassword.ForeColor = Color.Silver;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClassLogin lg = new ClassLogin();
            string mensaje;

            string user = this.textBoxUser.Text;
            string pass = this.textBoxPassword.Text;

            mensaje = lg.Loguearse(user, pass);

            if (mensaje.ToString() == "Administrador")
            {
                MessageBox.Show("Bienvenido Administrador");

                FormMenu menu = new FormMenu();
                menu.FormClosed += new FormClosedEventHandler(form2_FormClosed);
                menu.ShowDialog();

                textBoxUser.Text = "";
                textBoxPassword.Text = "";

            }
            else if (mensaje.ToString() == "Contador")
            {
                MessageBox.Show("Bienvenido Contador");

                FormMenu menu = new FormMenu();
                menu.FormClosed += new FormClosedEventHandler(form2_FormClosed);
                menu.ShowDialog();

                textBoxUser.Text = "";
                textBoxPassword.Text = "";
            }
            else
            {
                MessageBox.Show(mensaje);
                textBoxUser.Text = "";
                textBoxPassword.Text = "";
                textBoxUser.Focus();
            }
        }




        private void form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Enabled = true;



        }
    }
}
