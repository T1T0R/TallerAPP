

using Gestor_Pedidos_Tecnology.CapaDatos;
using Gestor_Pedidos_Tecnology.CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_Pedidos_Tecnology.CapaPresentacion
{
    public partial class FrmGestorTrabajos : Form
    {
        private TrabajosBL trabajos = new TrabajosBL();

        public FrmGestorTrabajos()
        {
            InitializeComponent();
            
        }

       


        private void FrmGestorTrabajos_Load(object sender, EventArgs e)
        {
            try
            {
                cmbTablas.Items.Add("Todos");
                cmbTablas.Items.Add("Clientes");
                cmbTablas.Items.Add("Equipos");
                cmbTablas.Items.Add("Trabajos");


                cmbTablas.SelectedIndex= 0;

                CargarDatos(cmbTablas.SelectedItem.ToString());

                this.MaximizeBox = false;

                // Centrar el formulario en la pantalla
                this.StartPosition = FormStartPosition.CenterScreen;
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;

                // Ajuste automático del tamaño del formulario para evitar espacio gris
                this.AutoSize = true;
                this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                // Estilo "Excel" para el DataGridView
                dgvGestorTrabajos.EnableHeadersVisualStyles = false;

                // Color de fondo general
                dgvGestorTrabajos.BackgroundColor = Color.White;

                // Cabecera de columnas con estilo más llamativo
                dgvGestorTrabajos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 51, 102); // Azul oscuro
                dgvGestorTrabajos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvGestorTrabajos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                dgvGestorTrabajos.ColumnHeadersHeight = 35;


                // Estilo de celdas normales
                dgvGestorTrabajos.DefaultCellStyle.BackColor = Color.White;
                dgvGestorTrabajos.DefaultCellStyle.ForeColor = Color.Black;
                dgvGestorTrabajos.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                dgvGestorTrabajos.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
                dgvGestorTrabajos.DefaultCellStyle.SelectionForeColor = Color.Black;

                // Filas alternas con fondo suave
                dgvGestorTrabajos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255); // Azul muy claro

                // Bordes tipo Excel (finos)
                dgvGestorTrabajos.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                dgvGestorTrabajos.GridColor = Color.LightGray;

                // Quitar bordes del encabezado para un look más limpio
                dgvGestorTrabajos.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;

                // Ajustar tamaño de filas
                dgvGestorTrabajos.RowTemplate.Height = 28;

                // Desactivar edición directa
                dgvGestorTrabajos.ReadOnly = true;

                // Alinear texto al centro para estética más limpia
                dgvGestorTrabajos.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Estilo de selección
                dgvGestorTrabajos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvGestorTrabajos.MultiSelect = false;





            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Método para cargar los datos según la tabla seleccionada
        private void CargarDatos(string tablaSeleccionada)
        {
            try
            {
                DataTable dt = trabajos.ObtenerDatos(tablaSeleccionada);  // Obtener los datos según la tabla seleccionada
                dgvGestorTrabajos.DataSource = dt;  // Mostrar los datos en el DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los trabajos: " + ex.Message);
            }
        }



        private void btnEliminarTrabajo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtIDEstado.Text, out int IDTrabajo))
                {
                    MessageBox.Show("Ingrese un ID válido.");
                    return;
                }

                if (MessageBox.Show("¿Estás seguro que deseas eliminar este trabajo?", "Confirmar Eliminación", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (trabajos.EliminarTrabajo(IDTrabajo))
                    {
                        MessageBox.Show("Trabajo eliminado correctamente.");
                        string tablaSeleccionada = cmbTablas.SelectedItem.ToString();
                        CargarDatos(tablaSeleccionada);


                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el trabajo.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el trabajo: " + ex.Message);
            }
        }

        private void btnAgregarPresupuesto_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtIDTrabajo.Text, out int IDTrabajo) || string.IsNullOrWhiteSpace(txtPresupuesto.Text) || !int.TryParse(txtPrecioArreglo.Text, out int PrecioArreglo))
                {
                    MessageBox.Show("Por favor, complete todos los campos correctamente.");
                    return;
                }

                if (trabajos.AgregarPresupuesto(IDTrabajo, txtPresupuesto.Text, PrecioArreglo))
                {
                    MessageBox.Show("Presupuesto agregado correctamente.");
                    string tablaSeleccionada = cmbTablas.SelectedItem.ToString();
                    CargarDatos(tablaSeleccionada);
                    LimpiarCampos();

                }
                else
                {
                    MessageBox.Show("Error al agregar el presupuesto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el presupuesto: " + ex.Message);
            }
        }

       private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones básicas
                if (cmbModificar.SelectedItem == null || string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(txtNuevoValor.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string columnaSeleccionada = cmbModificar.SelectedItem.ToString();
                string nuevoValor = txtNuevoValor.Text;
                int id = Convert.ToInt32(textBox1.Text);

                if(columnaSeleccionada == "Nombre del Cliente")
                {
                    columnaSeleccionada = "ApellidoNombre";

                }

                if (columnaSeleccionada== "Falla Declarada")
                {
                    columnaSeleccionada = "FallaDeclarada";
                }

                if(columnaSeleccionada == "Numero de Serie")
                {
                    columnaSeleccionada = "NumeroSerie";
                }

                if (columnaSeleccionada == "Precio del Arreglo")
                {
                    columnaSeleccionada = "PrecioArreglo";
                }

                // Si la columna es Control, Cable o Base, convertir "Sí" en 1 y "No" en 0
                if (columnaSeleccionada == "Control" || columnaSeleccionada == "Cable" || columnaSeleccionada == "Base")
                {
                    nuevoValor = ValidarSiNo(nuevoValor);
                }

                // Intentar actualizar el valor
                bool actualizado = trabajos.ActualizarValor(columnaSeleccionada, nuevoValor, id);

                if (actualizado)
                {
                    MessageBox.Show("Actualización exitosa.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefrescarTabla();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se encontró el registro con ese ID.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        

    }


    





        public string ValidarSiNo(string valor)
        {
            string valorLimpio = valor.Trim().ToLower();

            if (valorLimpio == "sí" || valorLimpio == "si" || valorLimpio == "1")
                return "1";

            if (valorLimpio == "no" || valorLimpio == "0")
                return "0";

            throw new ArgumentException("Entrada inválida: Use 'Sí' o 'No'.");
        }


        private void MenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLogin mostrarlogin = new FormLogin();

            this.Hide();

            mostrarlogin.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
         
            CargarDatos("Todos");
            cmbTablas.SelectedIndex = 0;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FormGanancias mostrarclientes = new FormGanancias();

            this.Hide();

            mostrarclientes.Show();
        }



      


        public void LimpiarCampos()
        {
            textBox1.Clear();
            txtIDTrabajo.Clear();
            txtIDEstado.Clear();
            txtPresupuesto.Clear();
            txtNuevoValor.Clear();
            txtPrecioArreglo.Clear();
            txtPresupuesto.Clear();
            txtBusquedaNombre.Clear();
            cmbModificar.SelectedIndex = -1;

        }

        private void BtnDevolucion_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si se ha seleccionado un trabajo válido
                if (!int.TryParse(txtIDEstado.Text, out int IDTrabajo))
                {
                    MessageBox.Show("Seleccione un trabajo para marcarlo como 'Devolución'.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verificar si el trabajo ya está marcado como "Devolución"
                string estadoActual = trabajos.ObtenerEstadoTrabajo(IDTrabajo); // Método en la capa lógica
                if (estadoActual == "Devolucion")
                {
                    MessageBox.Show("Este trabajo ya está marcado como 'Devolución'.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Confirmar la acción del usuario
                if (MessageBox.Show("¿Está seguro que desea marcar este trabajo como 'Devolución'?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Llamamos al método de la capa lógica para marcarlo como devolución
                    if (trabajos.TrabajoDevolucion(IDTrabajo))
                    {
                        MessageBox.Show("El trabajo ha sido marcado como 'Devolución'.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (cmbTablas.SelectedItem != null)
                        {
                            string tablaSeleccionada = cmbTablas.SelectedItem.ToString();
                            CargarDatos(tablaSeleccionada);
                        }
                        else
                        {
                            MessageBox.Show("Seleccione una tabla para actualizar los datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el estado del trabajo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al marcar como 'Devolución': " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(txtBusquedaNombre.Text))
                {
                    MessageBox.Show("Por favor, ingrese un nombre para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cmbTipoEquipo.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, seleccione una categoría de equipo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string NombreBusqueda = txtBusquedaNombre.Text.Trim().ToLower();
                string CategoriaBusqueda = cmbTipoEquipo.SelectedItem?.ToString().Trim().ToLower() ?? ""; // Evitar null


                DataTable resultados = trabajos.BuscarTrabajo(NombreBusqueda, CategoriaBusqueda);
                dgvGestorTrabajos.DataSource = resultados.Rows.Count > 0 ? resultados : null;



                if (resultados.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron trabajos con los criterios de búsqueda.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al buscar los trabajos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIDEstado.Text))
                {
                    MessageBox.Show("Por favor, ingrese un nombre para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                int IDBusqueda = Convert.ToInt32(txtIDEstado.Text);

                DataTable resultados = trabajos.BuscarTrabajoID(IDBusqueda);

                dgvGestorTrabajos.DataSource = resultados.Rows.Count > 0 ? resultados : null;



                if (resultados.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron trabajos con los criterios de búsqueda.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LimpiarCampos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al buscar los trabajos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void cmbTablas_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string tablaSeleccionada = cmbTablas.SelectedItem.ToString();

            CargarDatos(tablaSeleccionada);
        }

        private void RefrescarTabla()
        {
            try
            {
                if (cmbModificar.SelectedItem == null)
                    return;

                string columnaSeleccionada = cmbModificar.SelectedItem.ToString();

                if (
                    columnaSeleccionada == "DNI" ||
                    columnaSeleccionada == "Nombre del Cliente" ||
                    columnaSeleccionada == "Telefono" ||
                    columnaSeleccionada == "Domicilio")
                {
                    dgvGestorTrabajos.DataSource = trabajos.ObtenerClientes(); // Método para obtener todos los clientes
                }
                else if (
                         
                         columnaSeleccionada == "Equipo" ||
                         columnaSeleccionada == "Falla Declarada" ||
                         columnaSeleccionada == "Modelo" ||
                         columnaSeleccionada == "Numero de Serie" ||
                         columnaSeleccionada == "Detalles" ||
                         columnaSeleccionada == "Control" ||
                         columnaSeleccionada == "Cable" ||
                         columnaSeleccionada == "Base" ||
                         columnaSeleccionada=="Categoria")
                {
                    dgvGestorTrabajos.DataSource = trabajos.ObtenerEquipos(); // Método para obtener todos los equipos
                }
                else if (
                         columnaSeleccionada == "Presupuesto" ||
                         columnaSeleccionada == "Precio del Arreglo")
                {
                    dgvGestorTrabajos.DataSource = trabajos.ObtenerTrabajos(); // Método para obtener todos los trabajos
                }
                else
                {
                    MessageBox.Show("La columna seleccionada no pertenece a ninguna tabla válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la tabla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    

        private void txtIDTrabajo_Enter(object sender, EventArgs e)
        {
            try
            {
                // Obtener todos los clientes de la base de datos
                DataTable trabajosDt = trabajos.ObtenerTrabajos();

                // Mostrar los clientes en el DataGridView
                dgvGestorTrabajos.DataSource = trabajosDt.Rows.Count > 0 ? trabajosDt : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los trabajos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPresupuesto_Enter(object sender, EventArgs e)
        {
            try
            {
                // Obtener todos los clientes de la base de datos
                DataTable trabajosDt = trabajos.ObtenerTrabajos();

                // Mostrar los clientes en el DataGridView
                dgvGestorTrabajos.DataSource = trabajosDt.Rows.Count > 0 ? trabajosDt : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los trabajos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPrecioArreglo_Enter(object sender, EventArgs e)
        {
            try
            {
                // Obtener todos los clientes de la base de datos
                DataTable trabajosDt = trabajos.ObtenerTrabajos();

                // Mostrar los clientes en el DataGridView
                dgvGestorTrabajos.DataSource = trabajosDt.Rows.Count > 0 ? trabajosDt : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los trabajos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtIDEstado_Enter(object sender, EventArgs e)
        {
            try
            {
                // Obtener todos los clientes de la base de datos
                DataTable trabajosDt = trabajos.ObtenerTrabajos();

                // Mostrar los clientes en el DataGridView
                dgvGestorTrabajos.DataSource = trabajosDt.Rows.Count > 0 ? trabajosDt : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los trabajos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbModificar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Verifica si se ha seleccionado un índice válido
                if (cmbModificar.SelectedIndex > -1)
                {
                    string seleccion = cmbModificar.SelectedItem.ToString();
                    DataTable resultados = new DataTable();

                    if (seleccion == "DNI" || seleccion == "Nombre del Cliente" || seleccion == "Domicilio" || seleccion == "Telefono")
                    {
                        resultados = trabajos.ObtenerClientes();
                        label11.Text = "Ingrese el ID del Cliente:";
                    }
                    else if (seleccion == "Equipo" || seleccion == "Categoria" || seleccion == "Falla Declarada" || seleccion == "Modelo" ||
                             seleccion == "Numero de Serie" || seleccion == "Detalles" || seleccion == "Control" ||
                             seleccion == "Cable" || seleccion == "Base")
                    {
                        resultados = trabajos.ObtenerEstadoEquipos();
                        label11.Text = "Ingrese el Codigo del Equipo:";
                    }
                    else if (seleccion == "Presupuesto" || seleccion == "Precio del Arreglo")
                    {
                        resultados = trabajos.ObtenerTrabajos();
                        label11.Text = "Ingrese el Codigo del Trabajo:";
                    }
                    else
                    {
                        label11.Text = "Ingrese el ID correspondiente:";
                    }

                    dgvGestorTrabajos.DataSource = resultados;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



     

        private void CargarTrabajos(string estado)
        {
            dgvGestorTrabajos.DataSource = trabajos.ObtenerTrabajosPorEstado(estado);
        }

        private void CargarTrabajosCategoria(string Categoria)
        {
            dgvGestorTrabajos.DataSource = trabajos.ObtenerTrabajosPorCategoria(Categoria);
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormTrabajoIngreso mostrarmenu = new FormTrabajoIngreso();

            this.Hide();

            mostrarmenu.Show();
        }

        private void PendientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CargarTrabajos("Pendiente");

        }


        private void DevueltosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarTrabajos("Devolucion");

        }

        private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            CargarTrabajosCategoria("Televisores");
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            CargarTrabajosCategoria("Audio");

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            CargarTrabajosCategoria("Otros");

        }

        private void EntregadoStripMenuItem6_Click(object sender, EventArgs e)
        {
            CargarTrabajos("Entregado");
        }

   

       
        private void txtTelefono_Enter(object sender, EventArgs e)
        {
            try
            {
                // Obtener todos los clientes de la base de datos
                DataTable trabajosDt = trabajos.ObtenerClientes();

                // Mostrar los clientes en el DataGridView
                dgvGestorTrabajos.DataSource = trabajosDt.Rows.Count > 0 ? trabajosDt : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los trabajos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si se ha seleccionado un trabajo
                if (string.IsNullOrWhiteSpace(txtIDEstado.Text) || !int.TryParse(txtIDEstado.Text, out int IDTrabajo))
                {
                    MessageBox.Show("Debe seleccionar un trabajo antes de marcarlo como 'Listo para entregar'.",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIDEstado.Focus();
                    return;
                }

                // Verificar si el trabajo tiene presupuesto y precio en la base de datos
                if (!trabajos.VerificarPresupuesto(IDTrabajo))  // Método que consulta la base de datos
                {
                    MessageBox.Show("Debe ingresar tanto el presupuesto como el precio del arreglo en la base de datos para marcar el trabajo como 'Listo para entregar'.",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener el estado actual del trabajo
                string estadoActual = trabajos.ObtenerEstadoTrabajo(IDTrabajo);

                // Evitar que se marque como "Listo para entregar" si ya está "Entregado"
                if (estadoActual == "Entregado")
                {
                    MessageBox.Show("No puede marcar como 'Listo para entregar' un trabajo que ya fue 'Entregado'.",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirmar acción
                if (MessageBox.Show("¿Está seguro que desea marcar este trabajo como 'Listo para entregar'?",
                                    "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (trabajos.MarcarTrabajoComoListo(IDTrabajo))
                    {
                        MessageBox.Show("El trabajo ha sido marcado como 'Listo para entregar'.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatos("Trabajos"); // Recargar la tabla
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el estado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al marcar como 'Listo para entregar': " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnListo_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si se ha seleccionado un trabajo
                if (string.IsNullOrWhiteSpace(txtIDEstado.Text) || !int.TryParse(txtIDEstado.Text, out int IDTrabajo))
                {
                    MessageBox.Show("Debe seleccionar un trabajo antes de marcarlo como 'Entregado'.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIDEstado.Focus();
                    return;
                }

                // Verificar si el trabajo ya está marcado como "Entregado"
                string estadoActual = trabajos.ObtenerEstadoTrabajo(IDTrabajo); // Método que obtiene el estado actual del trabajo

                if (estadoActual == "Entregado")
                {
                    MessageBox.Show("Este trabajo ya está marcado como 'Entregado'.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Verificar si el trabajo está marcado como "Listo para entregar" antes de entregarlo
                if (estadoActual != "Listo para entregar")
                {
                    MessageBox.Show("El trabajo debe estar marcado como 'Listo para entregar' antes de ser 'Entregado'.",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirmar si el usuario quiere marcar el trabajo como 'Entregado'
                if (MessageBox.Show("¿Está seguro que desea marcar este trabajo como 'Entregado'?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (trabajos.MarcarTrabajoComoEntregado(IDTrabajo)) // Método de la capa lógica
                    {
                        MessageBox.Show("El trabajo ha sido marcado como 'Entregado'.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (cmbTablas.SelectedItem != null)
                        {
                            string tablaSeleccionada = cmbTablas.SelectedItem.ToString();
                            CargarDatos(tablaSeleccionada);
                        }
                        else
                        {
                            MessageBox.Show("Seleccione una tabla para actualizar los datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el estado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al marcar como 'Entregado': " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            FormContactar mostrarcontactar = new FormContactar();

            mostrarcontactar.Show();
        }

        private void lISTOSPARAENTREGARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarTrabajos("Listo para entregar");
        }

        private void txtBusquedaNombre_Enter(object sender, EventArgs e)
        {
            try
            {
                // Obtener todos los clientes de la base de datos
                DataTable trabajosDt = trabajos.ObtenerClientes();

                // Mostrar los clientes en el DataGridView
                dgvGestorTrabajos.DataSource = trabajosDt.Rows.Count > 0 ? trabajosDt : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los trabajos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }

}


 



