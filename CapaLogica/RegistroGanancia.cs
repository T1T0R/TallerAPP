using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_Pedidos_Tecnology.CapaLogica
{
    public class RegistroGanancia
    {
        public int IdRegistro { get; set; }
        public DateTime FechaInicioSemana { get; set; }
        public DateTime FechaFinSemana { get; set; }
        public int Ganancia { get; set; }
    }
}
