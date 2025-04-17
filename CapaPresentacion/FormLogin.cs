using Gestor_Pedidos_Tecnology.CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_Pedidos_Tecnology.CapaPresentacion
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
     
            txtUsuario.Focus();

        }

        private TrabajosBL trabajosBL = new TrabajosBL();


        private void btnIniciarSesion_Click_1(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtPassword.Text.Trim();

            // Verificar que los campos no estén vacíos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar credenciales en la capa lógica
            if (trabajosBL.ValidarUsuario(usuario, contraseña))
            {
                MessageBox.Show($"Inicio de sesión exitoso, bienvenido {usuario} .", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir el formulario de ganancias y ocultar el de login
                FormGanancias formGanancias = new FormGanancias();
                this.Hide();
                formGanancias.Show();

            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
     

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Al iniciar el formulario, la contraseña se muestra como asteriscos
            txtPassword.PasswordChar = '*';


        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormTrabajoIngreso mostrarmenu = new FormTrabajoIngreso();
            this.Hide();
            mostrarmenu.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmGestorTrabajos formTrabajos = new FrmGestorTrabajos();
            this.Hide();
            formTrabajos.Show();
        }

        private void ChkContraseña_CheckedChanged_1(object sender, EventArgs e)
        {

            // Si el checkbox está marcado, mostrar la contraseña; de lo contrario, ocultarla
            txtPassword.PasswordChar = ChkContraseña.Checked ? '\0' : '*';
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Mover el foco a txtPassword cuando presionan Enter
                txtPassword.Focus();
                e.Handled = true;  // Evita que el Enter cause efectos no deseados en el texto
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Mover el foco al botón de Iniciar sesión
                btnIniciarSesion.Focus();
                e.Handled = true;  // Evita que el Enter cause efectos no deseados en el texto
            }
        }
    }
    
}
