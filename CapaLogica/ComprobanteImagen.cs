using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Gestor_Pedidos_Tecnology.CapaLogica
{
    public class ComprobanteImagen
    {
        public static void GenerarComprobante(string rutaSalida, Trabajo trabajo, Equipos equipo, Clientes cliente, int IdTrabajo)
        {
            try
            {
                int width = 1754;
                int height = 2480;

                using (Bitmap imagen = new Bitmap(width, height))
                {
                    using (Graphics g = Graphics.FromImage(imagen))
                    {
                        g.Clear(Color.White);

                        Font tituloFont = new Font("Arial", 40, FontStyle.Bold);
                        Font subtituloFont = new Font("Arial", 18, FontStyle.Bold);
                        Font boldFont = new Font("Arial", 28, FontStyle.Bold);
                        Font normalFont = new Font("Arial", 24);
                        Font avisoFont = new Font("Arial", 22, FontStyle.Bold);

                        // Dibuja el título en el lado izquierdo
                        g.DrawString("TALLER XXX SERVICE", tituloFont, Brushes.Black, new RectangleF(40, 40, width - 80, 100));

                        // Mide el tamaño del texto para "COMPROBANTE N°"
                        string comprobanteText = "COMPROBANTE N°:" + IdTrabajo;
                        SizeF textSize = g.MeasureString(comprobanteText, tituloFont);

                        // Calcula la posición para alinearlo a la derecha con un margen de 40 píxeles
                        float xPositionComprobante = width - textSize.Width -1; // Márgenes a la derecha
                        g.DrawString(comprobanteText, boldFont, Brushes.Black, new PointF(xPositionComprobante, 50)); // Se dibuja en la misma altura que el título

                        // Dibuja el resto del encabezado
                        g.DrawString("Dirección: [Dirección del Taller]", subtituloFont, Brushes.Black, new RectangleF(40, 120, width - 80, 100));
                        g.DrawString("Contacto: [Número de Teléfono o WhatsApp]", subtituloFont, Brushes.Black, new RectangleF(40, 160, width - 80, 100));

                        // Dibuja la línea divisoria
                        g.DrawLine(Pens.Black, 40, 220, width - 40, 220);

                        int yPosition = 250;


                        AgregarFilaImagen(g, ref yPosition, "Fecha de ingreso:", trabajo.FechaIngreso.ToString("dd/MM/yyyy"), boldFont, normalFont);
                        AgregarFilaImagen(g, ref yPosition, "Cliente:", cliente.ApellidoNombre, boldFont, normalFont);
                        AgregarFilaImagen(g, ref yPosition, "Domicilio:", cliente.Domicilio, boldFont, normalFont);
                        AgregarFilaImagen(g, ref yPosition, "Teléfono:", cliente.Telefono, boldFont, normalFont);
                        AgregarFilaImagen(g, ref yPosition, "Equipo:", equipo.Equipo, boldFont, normalFont);
                        AgregarFilaImagen(g, ref yPosition, "Modelo:", equipo.Modelo, boldFont, normalFont);
                        AgregarFilaImagen(g, ref yPosition, "N° de Serie:", equipo.NumeroSerie, boldFont, normalFont);
                        AgregarFilaImagen(g, ref yPosition, "Estado al ingresar:", equipo.FallaDeclarada + ", " + equipo.Detalles, boldFont, normalFont);
                        AgregarFilaImagen(g, ref yPosition, "Accesorios:", ObtenerAccesorios(equipo), boldFont, normalFont);
                        AgregarFilaImagen(g, ref yPosition, "Tarea a realizar:", "Presupuestar", boldFont, normalFont);

                        yPosition += 20;
                        g.DrawString("IMPORTANTE", boldFont, Brushes.Black, new RectangleF(40, yPosition, width - 80, 50));
                        yPosition += 50;
                        g.DrawString("Pasados 90 días sin retirar el equipo, no hay derecho a reclamo (Art. 872/873 C.C.).", normalFont, Brushes.Black, new RectangleF(40, yPosition, width - 80, 100));
                        yPosition += 50;

                        // Formato del texto para centrarlo y dividirlo correctamente en dos líneas
                        StringFormat formatoCentrado = new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        };

                        RectangleF rectAviso = new RectangleF(40, yPosition, width - 80, 100);
                        g.DrawString("PARA RETIRAR EL EQUIPO,DEBE PRESENTAR ESTE COMPROBANTE ORIGINAL", avisoFont, Brushes.Black, rectAviso, formatoCentrado);

                        yPosition += 120;

                        g.DrawLine(Pens.Black, 40, yPosition, width - 40, yPosition);
                        yPosition += 50;

                        g.DrawString("N° DE RECEPCION: " + IdTrabajo, boldFont, Brushes.Black, new PointF(40, yPosition));
                        g.DrawString("FECHA DE INGRESO: " + trabajo.FechaIngreso.ToString("dd/MM/yyyy"), boldFont, Brushes.Black, new PointF(500, yPosition));



                        imagen.Save(rutaSalida, ImageFormat.Png);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar la imagen: " + ex.Message);
            }
        }

        private static void AgregarFilaImagen(Graphics g, ref int yPosition, string etiqueta, string valor, Font boldFont, Font normalFont)
        {
            if (string.IsNullOrEmpty(valor))
            {
                valor = "N/A";
            }

            g.DrawString(etiqueta, boldFont, Brushes.Black, new RectangleF(40, yPosition, 500, 40));
            g.DrawString(valor, normalFont, Brushes.Black, new RectangleF(550, yPosition, 1200, 40));
            yPosition += 60;
        }

        private static string ObtenerAccesorios(Equipos equipo)
        {
            List<string> accesorios = new List<string>();
            if (equipo.Control) accesorios.Add("Control");
            if (equipo.Cable) accesorios.Add("Cable");
            if (equipo.Base) accesorios.Add("Base");

            return accesorios.Count > 0 ? string.Join(", ", accesorios) : "Ninguno";
        }
    }
}
