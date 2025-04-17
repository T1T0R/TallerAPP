using Gestor_Pedidos_Tecnology.CapaDatos;
using Gestor_Pedidos_Tecnology.CapaLogica;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http.Headers;
using System.Windows.Forms;

public class TrabajosBL
{

    private readonly TrabajosDAL trabajosDAL;

    public TrabajosBL()
    {
        trabajosDAL = new TrabajosDAL();
    }

    public int InsertarCliente(Clientes cliente)
    {
        return trabajosDAL.InsertarCliente(cliente);
    }

    public int InsertarEquipo(Equipos equipo)
    {
        return trabajosDAL.InsertarEquipo(equipo);
    }

    public int InsertarTrabajo(Trabajo trabajo)
    {
        return trabajosDAL.InsertarTrabajo(trabajo);
    }

    // Método para actualizar cualquier columna de la base de datos


    public int ObtenerIdClientePorDNI(int dni)
    {
        return trabajosDAL.ObtenerIdClientePorDNI(dni); // Verifica si el cliente existe y devuelve su IdCliente
    }

    public bool ActualizarValor(string columnaSeleccionada, object nuevoValor, int id)
    {
        string tabla = "";
        string idColumna = "";

        // Determinar a qué tabla pertenece la columna
        if (new List<string> { "DNI", "ApellidoNombre", "Telefono", "Domicilio" }.Contains(columnaSeleccionada.Trim()))
        {
            tabla = "Clientes";
            idColumna = "IdCliente";
        }
        else if (new List<string> { "FechaIngreso", "Estado", "Presupuesto", "PrecioArreglo" }.Contains(columnaSeleccionada.Trim()))
        {
            tabla = "Trabajos";
            idColumna = "IdTrabajo";
        }
        else if (new List<string> { "Equipo", "FallaDeclarada", "Modelo", "NumeroSerie", "Detalles", "Control", "Cable", "Base", "Categoria" }.Contains(columnaSeleccionada.Trim()))
        {
            tabla = "Equipos";
            idColumna = "IdEquipo";
        }
        else
        {
            throw new Exception($"Columna no válida. {columnaSeleccionada}");
        }

        return trabajosDAL.ActualizarColumna(tabla, columnaSeleccionada, nuevoValor, idColumna, id);
    }

    public DataTable BuscarTrabajoID(int IdTrabajoBusqueda)
    {
        return trabajosDAL.BuscarTrabajoID(IdTrabajoBusqueda);
    }

    public DataTable ObtenerClientes()
    {
        return trabajosDAL.ObtenerTodosLosClientes();
    }

    public DataTable ObtenerGanancias()
    {
        return trabajosDAL.ObtenerGanancias();
    }

    public string ObtenerEstadoTrabajo(int IDTrabajo)
    {
        return trabajosDAL.ObtenerEstadoTrabajo(IDTrabajo);
    }

    public DataTable ObtenerDatos(string tablaSeleccionada)
    {
        return trabajosDAL.EjecutarConsulta(tablaSeleccionada);
    }


    public bool AgregarPresupuesto(int IDTrabajo, string presupuesto, int precioArreglo)
    {
        // Agregar el presupuesto y el precio del arreglo
        bool actualizado = trabajosDAL.AgregarPresupuesto(IDTrabajo, presupuesto, precioArreglo);

        if (actualizado)
        {
            // Verificar si el trabajo ya está entregado
            if (trabajosDAL.EstaTrabajoEntregado(IDTrabajo))
            {
                // Si ya está entregado, asegurarse de que el precio se registre en ganancias
                trabajosDAL.ActualizarGananciasPorTrabajo(IDTrabajo);
            }
        }

        return actualizado;
    }

    public bool VerificarPresupuesto(int IDTrabajo)
    {
        return trabajosDAL.VerificarPresupuestoYPrecio(IDTrabajo);
    }

    public bool MarcarTrabajoComoListo(int IDTrabajo)
    {
        // Cambia el estado a "Listo para entregar"
        bool actualizado = trabajosDAL.MarcarComoListoParaEntregar(IDTrabajo);

        return actualizado;  // No actualizamos las ganancias aquí

    }

    public bool MarcarTrabajoComoEntregado(int IDTrabajo)
    {
        // Cambia el estado a "Entregado"
        bool actualizado = trabajosDAL.MarcarComoEntregado(IDTrabajo);

        if (actualizado)
        {
            // Verificar si ya tenía precio asignado antes de marcarlo como entregado
            trabajosDAL.ActualizarGananciasPorTrabajo(IDTrabajo);
        }

        return actualizado;
    }


    public bool EliminarTrabajo(int IDTrabajo)
    {
        return trabajosDAL.EliminarTrabajo(IDTrabajo);
    }

    public int ObtenerGananciaSemanal()
    {
        return trabajosDAL.ObtenerGananciaSemanal();
    }




    public bool ModificarPrecioArreglo(int IDTrabajo, int nuevoPrecio)
    {
        return trabajosDAL.ActualizarPrecioArreglo(IDTrabajo, nuevoPrecio);
    }



    public bool TrabajoDevolucion(int IDTrabajo)
    {
        try
        {
            // Llamamos al método de la capa de acceso a datos
            return trabajosDAL.MarcarTrabajoDevolucion(IDTrabajo);
        }
        catch (Exception ex)
        {
            // Manejo de errores: mostrar mensaje adecuado
            throw new Exception("Error al marcar trabajo como 'Devolución': " + ex.Message);
        }
    }


    public DataTable BuscarTrabajo(string NombreBusqueda, string CategoriaBusqueda)
    {

        return trabajosDAL.BuscarTrabajos(NombreBusqueda, CategoriaBusqueda);
    }

    //Estado
    public DataTable ObtenerEstadoEquipos()
    {
        return trabajosDAL.ObtenerLosEquipos();
    }

    //Categoria
    public DataTable ObtenerEquipos()
    {
        return trabajosDAL.ObtenerTodosLosEquipos();
    }



    public DataTable ObtenerTrabajos()
    {
        return trabajosDAL.ObtenerTodosLosTrabajos();
    }

    public int ObtenerIdClientePorDatos(string nombre, string telefono)
    {
        return trabajosDAL.ObtenerIdClientePorDatos(nombre, telefono);
    }


    public bool ValidarUsuario(string usuario, string contraseña)
    {
        return trabajosDAL.ValidarUsuario(usuario, contraseña);
    }

    public DataTable ObtenerTrabajosPorEstado(string estado)
    {
        return trabajosDAL.ObtenerTrabajosPorEstado(estado);
    }

    public DataTable ObtenerTrabajosPorCategoria(string categoria)
    {
        return trabajosDAL.ObtenerTrabajosCategoria(categoria);
    }
    public string GenerarEnlaceWhatsApp(int idCliente)
    {
        string telefono = trabajosDAL.ObtenerTelefonoPorId(idCliente);

        if (string.IsNullOrEmpty(telefono))
        {
            throw new Exception("El cliente no tiene un número de teléfono registrado.");
        }

        // Formateamos el número para asegurarnos de que tenga el código de área correcto.
        telefono = FormatearTelefono(telefono);

        return $"https://web.whatsapp.com/send?phone={telefono}";


    }
    private string FormatearTelefono(string telefono)
    {
        // Eliminamos espacios y guiones
        telefono = telefono.Trim().Replace(" ", "").Replace("-", "");

        // Si ya tiene formato internacional, lo dejamos igual
        if (telefono.StartsWith("+"))
        {
            return telefono;
        }

        // Si empieza con "381" (código de Tucumán), agregamos el prefijo internacional +549
        if (telefono.StartsWith("381"))
        {
            telefono = "+549" + telefono;
        }
        else if (telefono.Length == 10)
        {
            // Si tiene 10 dígitos, asumimos que es un número de celular sin 0 inicial
            telefono = "+549" + telefono;
        }
        else if (telefono.Length == 8)
        {
            // Si tiene 8 dígitos, asumimos que es un número fijo de Tucumán sin código de área
            telefono = "+54381" + telefono;
        }
        else
        {
            throw new Exception("Formato de teléfono no reconocido.");
        }

        return telefono;
    }


}


