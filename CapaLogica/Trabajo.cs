using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_Pedidos_Tecnology.CapaLogica
{
    public class Trabajo
    {
        public Trabajo() 
        {
            Estado = "Pendiente";
            PrecioArreglo = 0;
            FechaEntrega=null;
        }
        public int IdTrabajo { get; set; }
        public int IdEquipo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Estado { get; set; }
        public string Presupuesto { get; set; }
        public int PrecioArreglo { get; set; }
        public DateTime? FechaEntrega { get; set; }  // Puede ser null si aún no se ha entregado

        // Método para cambiar el estado del trabajo a "Entregado" o "Devolución"
        public void MarcarComoEntregado(DateTime fechaEntrega)
        {
            Estado = "Entregado";
            FechaEntrega = fechaEntrega;
            // Lógica para agregar el monto del arreglo a las ganancias
            // Aquí se podría llamar a un servicio para actualizar las ganancias de la semana
        }

        public void MarcarComoDevolucion(DateTime fechaDevolucion)
        {
            Estado = "Devolucion";
            FechaEntrega = fechaDevolucion;
            // Lógica para agregar el monto del arreglo a las ganancias, si es necesario
        }

        // Método para restablecer el estado a "Pendiente" y borrar la fecha de entrega
        public void MarcarComoPendiente()
        {
            Estado = "Pendiente";
            FechaEntrega = null;  // Si el estado es Pendiente, la fecha de entrega debe ser null
        }
    }

}
