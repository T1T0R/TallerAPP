using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_Pedidos_Tecnology.CapaLogica
{
    public class Equipos
    {
             public int IdEquipo { get; set; }
             public int IdCliente { get; set; }
            public string Equipo { get; set; }
            public string Categoria { get; set; }
            public string FallaDeclarada { get; set; }
            public string Modelo { get; set; }
            public string NumeroSerie { get; set; }
            public string Detalles { get; set; }
            public bool Control { get; set; }
            public bool Cable { get; set; }
            public bool Base { get; set; }

    }
}
