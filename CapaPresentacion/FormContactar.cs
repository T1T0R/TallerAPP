using Gestor_Pedidos_Tecnology.CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_Pedidos_Tecnology.CapaPresentacion
{
    public partial class FormContactar : Form
    {
        private TrabajosBL trabajos = new TrabajosBL();

        public FormContactar()
        {
            InitializeComponent();
        }

        private void btnContactar_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtTelefono.Text, out int idCliente))
                {
                    string enlaceWhatsApp = trabajos.GenerarEnlaceWhatsApp(idCliente);
                    System.Diagnostics.Process.Start(new ProcessStartInfo { FileName = enlaceWhatsApp, UseShellExecute = true });
                    txtTelefono.Clear();
                }
                else
                {
                    MessageBox.Show("Ingrese un ID de cliente válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        
    }
}
