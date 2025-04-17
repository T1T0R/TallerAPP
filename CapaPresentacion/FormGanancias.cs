using Gestor_Pedidos_Tecnology.CapaLogica;
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
    public partial class FormGanancias : Form
    {

        private TrabajosBL trabajoss = new TrabajosBL();
        public FormGanancias()
        {
            InitializeComponent();
        }

        private void MenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTrabajoIngreso mostrartrabajo = new FormTrabajoIngreso();

            this.Hide();

            mostrartrabajo.Show();
        }


        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmGestorTrabajos formTrabajos = new FrmGestorTrabajos();


            this.Hide();

            formTrabajos.Show();
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            // Aplicar un diseño más limpio
            dgvGanancias.ReadOnly = true;
            dgvGanancias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGanancias.MultiSelect = false;

            // Mejorar la visibilidad de las filas alternando colores
            dgvGanancias.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvGanancias.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dgvGanancias.DefaultCellStyle.SelectionForeColor = Color.White;

            // Evitar que las filas ocupen demasiado espacio
            dgvGanancias.RowHeadersVisible = false;



            this.MaximizeBox = false;
            this.WindowState = FormWindowState.Normal;

            // Asignar datos al DataGridView
            dgvGanancias.DataSource = trabajoss.ObtenerGanancias();






        }


        private void button6_Click(object sender, EventArgs e)
        {
            FormTrabajoIngreso mostrarmenu = new FormTrabajoIngreso();

            this.Hide();

            mostrarmenu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGestorTrabajos mostrargestor = new FrmGestorTrabajos();

            this.Hide();

            mostrargestor.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormTrabajoIngreso mostrarmenu = new FormTrabajoIngreso();
            this.Hide();
            mostrarmenu.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
                FrmGestorTrabajos formTrabajos = new FrmGestorTrabajos();
                this.Hide();
                formTrabajos.Show();
        }
    }
}


