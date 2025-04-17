using Gestor_Pedidos_Tecnology.CapaLogica;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PdfiumViewer;
using System.Drawing.Printing;
using System.Diagnostics;
using System.Linq;
using System.Drawing.Imaging;
using System.Net;

namespace Gestor_Pedidos_Tecnology.CapaPresentacion
{
    public partial class FormTrabajoIngreso : Form
    {
        private TrabajosBL trabajosBL = new TrabajosBL();

        public FormTrabajoIngreso()
        {
            InitializeComponent();
            // Ocultar los elementos al iniciar el formulario
            ChkLED.Visible = false;
            ChkLCD.Visible = false;
            ChkTUBO.Visible = false;

            label17.Visible = false;
            label18.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
        }

        private void btnAgregarTrabajo_Click(object sender, EventArgs e)
        {

            if (cmbCategoria.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona una categoría antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar nombre del cliente
            if (string.IsNullOrWhiteSpace(txtNombreCliente.Text))
            {
                MessageBox.Show("El nombre del cliente es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(txtNombreCliente.Text, @"^[a-zA-ZÁÉÍÓÚÑáéíóúñ\s]+$"))
            {
                MessageBox.Show("Formato inválido: El nombre solo debe contener letras y espacios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Validar DNI si se ingresó
            string dniTexto = txtDNI.Text.Trim();
            int dni = 0; // Si no se ingresa, se guardará como 0 en la BD

            if (!string.IsNullOrWhiteSpace(dniTexto))
            {
                if (!Regex.IsMatch(dniTexto, @"^\d{7,8}$"))
                {
                    MessageBox.Show("Formato inválido: El DNI debe contener solo números y tener entre 7 y 8 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (!int.TryParse(dniTexto, out dni))
                {
                    MessageBox.Show("Error al convertir el DNI a número.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dni = Convert.ToInt32(dniTexto); // Convertimos solo si es válido
            }

            // Validar teléfono argentino (línea fija: 7-8 dígitos, celular: 10 dígitos)
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("El número de teléfono es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            // Validar domicilio (permite letras, números y caracteres comunes)
            if (string.IsNullOrWhiteSpace(txtDomicilio.Text))
            {
                MessageBox.Show("El domicilio es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(txtDomicilio.Text, @"^[a-zA-Z0-9ÁÉÍÓÚÑáéíóúñ\s.,#-]+$"))
            {
                MessageBox.Show("Formato inválido: El domicilio solo puede contener letras, números y algunos caracteres especiales (.,#-).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            // Validar que los campos de equipo no estén vacíos
            if (string.IsNullOrWhiteSpace(txtEquipo.Text))
            {
                MessageBox.Show("El equipo es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFallaDeclarada.Text))
            {
                MessageBox.Show("Debes ingresar la falla declarada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtModelo.Text))
            {
                MessageBox.Show("Debes ingresar el modelo del equipo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSerie.Text))
            {
                MessageBox.Show("Debes ingresar el número de serie.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtObservaciones.Text))
            {
                MessageBox.Show("Debes ingresar detalles adicionales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            // Crear el objeto cliente
            Clientes nuevoCliente = new Clientes()
            {
                DNI = dni, // Si es 0, lo tratamos como indocumentado
                ApellidoNombre = txtNombreCliente.Text,
                Telefono = txtTelefono.Text,
                Domicilio = txtDomicilio.Text
            };

            int idClienteExistente;

            // Si tiene DNI, buscar por DNI; si es indocumentado, buscar por Nombre + Teléfono
            if (dni > 0)
            {
                idClienteExistente = trabajosBL.ObtenerIdClientePorDNI(nuevoCliente.DNI);
            }
            else
            {
                idClienteExistente = trabajosBL.ObtenerIdClientePorDatos(nuevoCliente.ApellidoNombre, nuevoCliente.Telefono);
            }

            if (idClienteExistente > 0)
            {

                // Cliente ya existe, reutilizamos su ID
                nuevoCliente.IdCliente = idClienteExistente;
            }
            else
            {
                // Cliente nuevo, lo insertamos
                nuevoCliente.IdCliente = trabajosBL.InsertarCliente(nuevoCliente);
            }


            Equipos nuevoEquipo = new Equipos() //:)
            {
                IdCliente = nuevoCliente.IdCliente,
                Equipo = txtEquipo.Text,
                Categoria = cmbCategoria.Text,
                FallaDeclarada = txtFallaDeclarada.Text,
                Modelo = txtModelo.Text,
                NumeroSerie = txtSerie.Text,
                Detalles = txtObservaciones.Text,
                Control = cbControl.Checked,
                Cable = cbCable.Checked,
                Base = cbBase.Checked
            };

            nuevoEquipo.IdEquipo = trabajosBL.InsertarEquipo(nuevoEquipo);

            if (nuevoEquipo.IdEquipo <= 0)
            {
                MessageBox.Show("No se pudo registrar el equipo. Revisa los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (nuevoEquipo.IdEquipo == 0)
            {
                MessageBox.Show("Error al insertar el equipo. No se puede continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;  // Evita continuar si el equipo no fue insertado correctamente
            }

            Trabajo nuevoTrabajo = new Trabajo
            {
                IdEquipo = nuevoEquipo.IdEquipo,
                FechaIngreso = dtpFecha.Value,
                Presupuesto = string.Empty,
                PrecioArreglo = 0
            };

            var confirmacion = MessageBox.Show("¿Estás seguro de que deseas agregar este trabajo?",
                                                "Confirmar Operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    // Insertar el trabajo y obtener el ID
                    int idTrabajo = trabajosBL.InsertarTrabajo(nuevoTrabajo);

                    if (idTrabajo > 0)
                    {
                        string carpetaLocal = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Comprobantes");

                        // Limpiar el nombre del cliente para que sea un nombre de archivo válido
                        string nombreLimpio = string.Concat(nuevoCliente.ApellidoNombre.Where(c => !Path.GetInvalidFileNameChars().Contains(c)));

                        string rutaImagen;

                        // Crear la carpeta "Comprobantes" en el escritorio si no existe
                        if (!Directory.Exists(carpetaLocal))
                        {
                            Directory.CreateDirectory(carpetaLocal);
                        }

                        // Ruta de la imagen que se va a generar
                        rutaImagen = Path.Combine(carpetaLocal, $"Trabajo_{idTrabajo}_Cliente_{nombreLimpio}.png");
                        ComprobanteImagen.GenerarComprobante(rutaImagen, nuevoTrabajo, nuevoEquipo, nuevoCliente, idTrabajo);

                        // Imprimir el comprobante automáticamente
                        if (File.Exists(rutaImagen))
                        {
                            PrintDocument printDoc = new PrintDocument();
                            printDoc.PrintPage += (senderi, ei) =>
                            {
                                using (Image imagen = Image.FromFile(rutaImagen))
                                {
                                    Rectangle destRect = new Rectangle(0, 0, ei.PageBounds.Width, ei.PageBounds.Height);
                                    ei.Graphics.DrawImage(imagen, destRect);
                                }
                            };
                            printDoc.Print();
                            MessageBox.Show("Trabajo agregado, comprobante guardado e impreso con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error: la imagen de comprobante no se ha generado correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar el trabajo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }





        // Método para controlar el flujo de las teclas en los controles
        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;  // Evita el sonido de error al presionar Enter

                // Validación de campos no vacíos antes de mover el foco
                if (string.IsNullOrEmpty(((TextBox)sender).Text))
                {
                    MessageBox.Show("Este campo no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;  // Detener el flujo si el campo está vacío
                }

                // Flujo de enfoque entre los controles
                if (sender == cmbCategoria) txtDNI.Focus();  // Cuando se selecciona una categoría, va a DNI
                else if (sender == txtDNI) txtNombreCliente.Focus();  // Luego al NombreCliente
                else if (sender == txtNombreCliente) txtTelefono.Focus();  // Después al Teléfono
                else if (sender == txtTelefono) txtDomicilio.Focus();  // Luego Domicilio
                else if (sender == txtDomicilio) txtEquipo.Focus();  // Luego va al Equipo
                else if (sender == txtEquipo) txtFallaDeclarada.Focus();  // Falla
                else if (sender == txtFallaDeclarada) txtModelo.Focus();  // Luego Modelo
                else if (sender == txtModelo) txtSerie.Focus();  // Después Número de Serie
                else if (sender == txtSerie) txtObservaciones.Focus();  // Luego Observaciones
                else if (sender == txtObservaciones) btnAgregarTrabajo.Focus();  // Finalmente al botón Agregar Trabajo
            }
        }



        private void LimpiarCampos()
        {
            txtDNI.Clear();
            txtEquipo.Clear();
            txtModelo.Clear();
            txtSerie.Clear();
            txtDomicilio.Clear();
            txtNombreCliente.Clear();
            txtTelefono.Clear();
            txtFallaDeclarada.Clear();
            txtObservaciones.Clear();
            cbControl.Checked = false;
            cbCable.Checked = false;
            cbBase.Checked = false;
            ChkLED.Checked = false;
            ChkLCD.Checked = false;
            ChkTUBO.Checked = false;
            cmbCategoria.SelectedIndex = -1; // Desmarcar la categoría
        }


        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmGestorTrabajos formTrabajos = new FrmGestorTrabajos();
            this.Hide();
            formTrabajos.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FormGanancias mostrarclientes = new FormGanancias();
            this.Hide();
            mostrarclientes.Show();
        }

        private void FormTrabajoIngreso_Load(object sender, EventArgs e)
        {
            // Al cargar el formulario, se selecciona el ComboBox y se abre
            cmbCategoria.Focus();
            cmbCategoria.DroppedDown = false;
            this.MaximizeBox = false;

            // Conectar los eventos KeyDown de los controles con el método Control_KeyDown
            txtDNI.KeyDown += Control_KeyDown;
            txtNombreCliente.KeyDown += Control_KeyDown;
            txtTelefono.KeyDown += Control_KeyDown;
            txtDomicilio.KeyDown += Control_KeyDown;
            txtEquipo.KeyDown += Control_KeyDown;
            txtFallaDeclarada.KeyDown += Control_KeyDown;
            txtModelo.KeyDown += Control_KeyDown;
            txtSerie.KeyDown += Control_KeyDown;
            txtObservaciones.KeyDown += Control_KeyDown;
        }

        private void txtDNI_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtNombreCliente_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtDomicilio_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtEquipo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtFallaDeclarada_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtModelo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtSerie_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtObservaciones_KeyDown(object sender, KeyEventArgs e)
        {

        }



        private void ChkLED_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkLED.Checked)
            {
                ChkLCD.Checked = false;
                ChkTUBO.Checked = false;
            }
        }

        private void ChkLCD_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkLCD.Checked)
            {
                ChkLED.Checked = false;
                ChkTUBO.Checked = false;
            }
        }

        private void ChkTUBO_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkTUBO.Checked)
            {
                ChkLCD.Checked = false;
                ChkLED.Checked = false;
            }
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esTelevisor = cmbCategoria.SelectedIndex != -1 && cmbCategoria.SelectedItem.ToString() == "Televisores";

            // Mostrar/ocultar los Checkboxes y Labels según la categoría seleccionada
            ChkLED.Visible = esTelevisor;
            ChkLCD.Visible = esTelevisor;
            ChkTUBO.Visible = esTelevisor;

            label17.Visible = esTelevisor;
            label18.Visible = esTelevisor;
            label21.Visible = esTelevisor;
            label22.Visible = esTelevisor;

            // Desmarcar los checkboxes de tipo de televisor si no es "Televisores"
            if (!esTelevisor)
            {
                ChkLED.Checked = false;
                ChkLCD.Checked = false;
                ChkTUBO.Checked = false;
            }

            // Asegurarse de que los checkboxes de accesorios estén desmarcados
            cbControl.Checked = false;
            cbCable.Checked = false;
            cbBase.Checked = false;

            // Hacer que los checkboxes de tipo de televisor estén ocultos si no es "Televisores"
            if (!esTelevisor)
            {
                ChkLED.Visible = false;
                ChkLCD.Visible = false;
                ChkTUBO.Visible = false;
            }
        }

        private void cmbCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica si se presionó Enter y si hay una categoría seleccionada
            if (e.KeyCode == Keys.Enter && cmbCategoria.SelectedIndex != -1)
            {
                // Mueve el foco al TextBox de DNI
                txtDNI.Focus();
                e.SuppressKeyPress = true; // Evita el sonido de error al presionar Enter
            }
        }
    }
}

