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

namespace UI
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void AbrirFormInPanel(object formHijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void mostrarlogoAlCerrarForm(object sender, FormClosedEventArgs e)
        {
            mostrarlogo();
        }


        int LX, LY, SW, SH;

        private void btnmenu_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 57)
            {
                MenuVertical.Width = 250;
            }
            else

                MenuVertical.Width = 57;
        }

        private void iconMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        public void btnINICIO_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormLogo());
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            mostrarlogo();
        }

        private void mostrarlogo()
        {
            AbrirFormInPanel(new FormLogo());
        }

        private void btnCLIENTES_Click(object sender, EventArgs e)
        {
            Cliente.FormListarCliente forCli = new Cliente.FormListarCliente();
            forCli.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
            AbrirFormInPanel(forCli);
        }

        private void buttonPRODUCTOS_Click(object sender, EventArgs e)
        {
            Producto.FormListarProducto forPro = new Producto.FormListarProducto();
            forPro.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
            AbrirFormInPanel(forPro);
        }

        private void buttonVENTAS_Click(object sender, EventArgs e)
        {
            Venta.FormListarVenta forVen = new Venta.FormListarVenta();
            forVen.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
            AbrirFormInPanel(forVen);
        }

        private void buttonCATEGORIAS_Click(object sender, EventArgs e)
        {
            Categorias.FormListarCategorias forCat = new Categorias.FormListarCategorias();
            forCat.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
            AbrirFormInPanel(forCat);
        }

        private void buttonUSUARIOS_Click(object sender, EventArgs e)
        {
            Usuarios.FormListarUsuarios formUsut = new Usuarios.FormListarUsuarios();
            formUsut.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
            AbrirFormInPanel(formUsut);
        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Salir?", "Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //tus codigos
                this.Close();

            }
            else
            {
                //tus codigos
            }
        }

        private void iconrestaurar_Click(object sender, EventArgs e)
        {
            this.Size = new Size(SW, SH);
            this.Location = new Point(LX, LY);
            iconmaximizar.Visible = true;
            iconrestaurar.Visible = false;
        }

        private void iconmaximizar_Click(object sender, EventArgs e)
        {
            LX = this.Location.X;
            LY = this.Location.Y;
            SW = this.Size.Width;
            SH = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            iconmaximizar.Visible = false;
            iconrestaurar.Visible = true;
        }
    }
}
