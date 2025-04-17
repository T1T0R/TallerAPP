using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_Pedidos_Tecnology.CapaLogica
{
    public class Clientes
    {
        public int IdCliente { get; set; }  // Cambiado a Id para coincidir con la BD

        public int DNI { get; set; }
        public string ApellidoNombre { get; set; }  // Cambiado a Id para coincidir con la BD

        public string Telefono { get; set; }  // Cambiado a Id para coincidir con la BD

        public string Domicilio { get; set; }  // Cambiado a Id para coincidir con la BD

    }
}
