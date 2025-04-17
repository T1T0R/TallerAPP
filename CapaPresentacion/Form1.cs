using Gestor_Pedidos_Tecnology.CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_Pedidos_Tecnology
{
    public partial class Form1 : Form
    {
        private ProductosBL productosBL = new ProductosBL();

        public Form1()
        {
            InitializeComponent();
            CargarProductos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Aquí puedes cargar las categorías al ComboBox si no las has cargado previamente
            // Ejemplo: cmbCategoria.Items.Add("Categoria 1");
            CargarProductos();
        }

        private void CargarProductos()
        {
            dgvProductos.DataSource = productosBL.ObtenerProductos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica que la categoría esté seleccionada
                if (cmbCategoria.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, seleccione una categoría.");
                    return;
                }

                // Asignar el valor de la categoría seleccionada del ComboBox
                string categoria = cmbCategoria.SelectedItem.ToString();

                // Agregar el producto con los valores del formulario
                productosBL.AgregarProducto(txtNombre.Text, categoria, txtDescripcion.Text, decimal.Parse(txtPrecio.Text), int.Parse(txtStock.Text));

                // Actualizar el DataGridView
                CargarProductos();

                // Limpiar campos
                LimpiarCampos();
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor, ingrese un formato valido.");

            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            // Asegúrate de que el ID no esté vacío
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Por favor, ingrese un ID válido.");
                return;
            }

            int idProducto = int.Parse(txtID.Text);
            productosBL.EliminarProducto(idProducto);
            CargarProductos();
            LimpiarCampos();
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            // Verifica que el ComboBox tenga una categoría seleccionada
            if (cmbCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione una categoría.");
                return;
            }

            // Obtener la categoría seleccionada
            string categoria = cmbCategoria.SelectedItem.ToString();

            // Modificar el producto con los valores ingresados en los campos
            productosBL.ModificarProducto(int.Parse(txtID.Text), txtNombre.Text, categoria, txtDescripcion.Text, decimal.Parse(txtPrecio.Text), int.Parse(txtStock.Text));

            // Actualizar los datos en el DataGridView
            CargarProductos();

            // Limpiar campos
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtStock.Clear();

            // Establece un valor por defecto para el ComboBox
            cmbCategoria.SelectedIndex = -1; // Desmarca cualquier selección
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
