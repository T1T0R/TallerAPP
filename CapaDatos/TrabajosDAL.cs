using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Gestor_Pedidos_Tecnology.CapaLogica;
using System.Collections.Generic;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Configuration;

namespace Gestor_Pedidos_Tecnology.CapaDatos
{

    public class TrabajosDAL
    {
        private readonly string connectionString;
        public TrabajosDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;

        }


        public int ObtenerIdClientePorDNI(int dni)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("SELECT IdCliente FROM Clientes WHERE DNI = @DNI", conn);
                cmd.Parameters.AddWithValue("@DNI", dni);

                conn.Open();
                var result = cmd.ExecuteScalar(); // Devuelve el IdCliente si existe, o null si no existe
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        public int InsertarCliente(Clientes cliente)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("INSERT INTO Clientes (DNI, ApellidoNombre, Telefono, Domicilio) OUTPUT INSERTED.IdCliente VALUES (@DNI, @ApellidoNombre, @Telefono, @Domicilio);", conn);
                cmd.Parameters.AddWithValue("@DNI", cliente.DNI);
                cmd.Parameters.AddWithValue("@ApellidoNombre", cliente.ApellidoNombre);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@Domicilio", cliente.Domicilio);

                conn.Open();
                var result = cmd.ExecuteScalar(); // Devuelve el IdCliente insertado
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        public int InsertarEquipo(Equipos equipo)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    var cmd = new SqlCommand(@"INSERT INTO Equipos (IdCliente, Equipo,Categoria, FallaDeclarada, Modelo, NumeroSerie, Detalles, Control, Cable, Base) 
                                       OUTPUT INSERTED.IdEquipo
                                       VALUES (@IdCliente, @Equipo,@Categoria, @FallaDeclarada, @Modelo, @NumeroSerie, @Detalles, @Control, @Cable, @Base);", conn);

                    cmd.Parameters.AddWithValue("@IdCliente", equipo.IdCliente);
                    cmd.Parameters.AddWithValue("@Equipo", equipo.Equipo);
                    cmd.Parameters.AddWithValue("@Categoria", equipo.Categoria);
                    cmd.Parameters.AddWithValue("@FallaDeclarada", equipo.FallaDeclarada);
                    cmd.Parameters.AddWithValue("@Modelo", equipo.Modelo);
                    cmd.Parameters.AddWithValue("@NumeroSerie", equipo.NumeroSerie);
                    cmd.Parameters.AddWithValue("@Detalles", equipo.Detalles);
                    cmd.Parameters.AddWithValue("@Control", equipo.Control);
                    cmd.Parameters.AddWithValue("@Cable", equipo.Cable);
                    cmd.Parameters.AddWithValue("@Base", equipo.Base);

                    conn.Open();
                    var result = cmd.ExecuteScalar(); // Devuelve el IdEquipo insertado

                    if (result == null)
                    {
                        MessageBox.Show("No se pudo obtener el IdEquipo después de la inserción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 0;
                    }

                    return Convert.ToInt32(result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar el equipo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            }
        }



        public int InsertarTrabajo(Trabajo trabajo)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("INSERT INTO Trabajos (IdEquipo, FechaIngreso, Estado, Presupuesto, PrecioArreglo) OUTPUT INSERTED.IdTrabajo VALUES (@IdEquipo, @FechaIngreso, @Estado, @Presupuesto, @PrecioArreglo);", conn);
                cmd.Parameters.AddWithValue("@IdEquipo", trabajo.IdEquipo); // Debe recibir IdEquipo
                cmd.Parameters.AddWithValue("@FechaIngreso", trabajo.FechaIngreso);
                cmd.Parameters.AddWithValue("@Estado", trabajo.Estado);
                cmd.Parameters.AddWithValue("@Presupuesto", trabajo.Presupuesto);
                cmd.Parameters.AddWithValue("@PrecioArreglo", trabajo.PrecioArreglo);

                conn.Open();
                var result = cmd.ExecuteScalar(); // Devuelve el IdTrabajo insertado
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }


        public bool EliminarTrabajo(int IDTrabajo)
        {
            string queryEliminar = "DELETE FROM Trabajos WHERE IdTrabajo = @IDTrabajo";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryEliminar, con);
                cmd.Parameters.AddWithValue("@IDTrabajo", IDTrabajo);

                try
                {
                    con.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0; // Devuelve true si el registro fue eliminado
                }
                catch (Exception ex)
                {
                    // Manejo del error
                    Console.WriteLine("Error al eliminar el registro: " + ex.Message);
                    return false;
                }
            }
        }

        public bool EliminarTrabajoCliente(int IDCliente)
        {
            string queryEliminarTrabajos = "DELETE FROM Trabajos WHERE IdCliente = @IDCliente";
            string queryEliminarCliente = "DELETE FROM Clientes WHERE IdCliente = @IDCliente";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlTransaction trans = con.BeginTransaction())
                    {
                        SqlCommand cmdTrabajos = new SqlCommand(queryEliminarTrabajos, con, trans);
                        cmdTrabajos.Parameters.AddWithValue("@IDCliente", IDCliente);
                        cmdTrabajos.ExecuteNonQuery();

                        SqlCommand cmdCliente = new SqlCommand(queryEliminarCliente, con, trans);
                        cmdCliente.Parameters.AddWithValue("@IDCliente", IDCliente);
                        int filasAfectadas = cmdCliente.ExecuteNonQuery();

                        trans.Commit();
                        return filasAfectadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar cliente: " + ex.Message);
                    return false;
                }
            }
        }


        public DataTable EjecutarConsulta(string categoria)
        {
            DataTable dt = new DataTable();
            string query = string.Empty;

            switch (categoria)
            {
                case "Todos":
                    query = @"
                    SELECT 
                        c.ApellidoNombre AS 'Cliente', 
                        c.Telefono AS 'Teléfono', 
                        c.Domicilio AS 'Domicilio', 
                        e.Equipo AS 'Equipo', 
                        e.FallaDeclarada AS 'Falla Reportada', 
                        e.Modelo AS 'Modelo', 
                        e.NumeroSerie AS 'Número de Serie', 
                        t.Estado AS 'Estado del Trabajo', 
                        t.Presupuesto AS 'Presupuesto Estimado', 
                        t.PrecioArreglo AS 'Costo de Reparación', 
                        t.FechaEntrega AS 'Fecha de Entrega'
                    FROM Clientes c
                    LEFT JOIN Equipos e ON c.IdCliente = e.IdCliente
                    LEFT JOIN Trabajos t ON e.IdEquipo = t.IdEquipo
                    ORDER BY c.IdCliente ASC, e.IdEquipo ASC, t.IdTrabajo ASC";
                    break;

                case "Clientes":
                    query = @"SELECT 
                    c.IdCliente AS 'ID Cliente',
                    c.DNI AS 'DNI Cliente', 
                    c.ApellidoNombre AS 'Apellido y Nombre', 
                    c.Telefono AS 'Teléfono', 
                    c.Domicilio AS 'Domicilio',
                    (SELECT COUNT(*) 
                     FROM Equipos e 
                     WHERE e.IdCliente = c.IdCliente) AS 'Cantidad de Equipos',
                    (SELECT COUNT(*) 
                     FROM Trabajos t 
                     INNER JOIN Equipos e ON t.IdEquipo = e.IdEquipo 
                     WHERE e.IdCliente = c.IdCliente
                     AND t.Estado != 'Entregado') AS 'Trabajos en Curso'
                FROM Clientes c
                ORDER BY c.IdCliente ASC;

                              ";
                    break;

                case "Equipos":
                    query = @"
                SELECT 
                    e.IdEquipo AS 'Código del Equipo',
                    e.Equipo AS 'Equipo', 
                    e.Categoria AS 'Categoría',
                    e.FallaDeclarada AS 'Falla Reportada', 
                    e.Modelo AS 'Modelo', 
                    e.NumeroSerie AS 'Número de Serie', 
                    e.Control AS 'Control',
                    e.Cable AS 'Cable',
                    e.Base AS 'Base',
                    c.ApellidoNombre AS 'Cliente'
                FROM Equipos e
                INNER JOIN Clientes c ON e.IdCliente = c.IdCliente
                ORDER BY e.IdEquipo ASC";
                    break;

                case "Trabajos":
                    query = @"
                SELECT 
                    t.IdTrabajo AS 'Numero de Trabajo',
                    t.FechaIngreso AS 'Fecha de Ingreso', 
                    t.Estado AS 'Estado del Trabajo', 
                    t.Presupuesto AS 'Presupuesto Estimado', 
                    t.PrecioArreglo AS 'Costo de Reparación', 
                    t.FechaEntrega AS 'Fecha de Entrega',
                    c.ApellidoNombre AS 'Cliente'
                FROM Trabajos t
                INNER JOIN Equipos e ON t.IdEquipo = e.IdEquipo
                INNER JOIN Clientes c ON e.IdCliente = c.IdCliente
                ORDER BY t.IdTrabajo ASC";
                    break;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    con.Open();
                    da.Fill(dt);
                }
            }

            return dt;
        }





        public bool AgregarPresupuesto(int IDTrabajo, string presupuesto, int precioArreglo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE Trabajos SET Presupuesto = @Presupuesto, PrecioArreglo = @PrecioArreglo WHERE IdTrabajo = @IdTrabajo";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Presupuesto", presupuesto);
                    cmd.Parameters.AddWithValue("@PrecioArreglo", precioArreglo);
                    cmd.Parameters.AddWithValue("@IdTrabajo", IDTrabajo);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Verificar si el trabajo tiene presupuesto y precio del arreglo en la base de datos
        public bool VerificarPresupuestoYPrecio(int IDTrabajo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Presupuesto, PrecioArreglo FROM Trabajos WHERE IdTrabajo = @IdTrabajo";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@IdTrabajo", IDTrabajo);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string presupuesto = reader.IsDBNull(0) ? null : reader.GetString(0);
                            int precioArreglo = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);




                            // Verificar si el presupuesto no está vacío y el precio del arreglo es mayor a 0
                            return !string.IsNullOrWhiteSpace(presupuesto) && precioArreglo > 0;
                        }
                    }
                }
            }

            return false; // Si no se encuentra el trabajo o no tiene presupuesto y precio
        }



        public bool MarcarComoListoParaEntregar(int IDTrabajo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "UPDATE Trabajos SET Estado = 'Listo para entregar' WHERE IdTrabajo = @IdTrabajo";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add("@IdTrabajo", SqlDbType.Int).Value = IDTrabajo;

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Logear o manejar el error de forma adecuada
                Console.WriteLine("Error al actualizar el estado del trabajo: " + ex.Message);
                return false; // O puedes retornar algún valor o lanzar la excepción
            }
        }

        public bool MarcarComoEntregado(int IDTrabajo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "UPDATE Trabajos SET Estado = 'Entregado', FechaEntrega = GETDATE() WHERE IdTrabajo = @IdTrabajo";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Cambiar AddWithValue por Add con tipo de datos explícito
                        cmd.Parameters.Add("@IdTrabajo", SqlDbType.Int).Value = IDTrabajo;

                        // Ejecuta la consulta y devuelve true si se afectaron filas
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Aquí puedes loguear el error o manejarlo de la forma que consideres
                Console.WriteLine("Error al actualizar el estado del trabajo: " + ex.Message);
                return false;
            }
        }


        // Método que construye y ejecuta la consulta
        public bool ActualizarColumna(string tabla, string columna, object nuevoValor, string idColumna, int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = $"UPDATE {tabla} SET {columna} = @NuevoValor WHERE {idColumna} = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NuevoValor", nuevoValor);
                    cmd.Parameters.AddWithValue("@ID", id);

                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }

            }
        }
        public string ObtenerEstadoTrabajo(int idTrabajo)
        {
            string estado = "";
            string query = "SELECT Estado FROM Trabajos WHERE IdTrabajo = @IdTrabajo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdTrabajo", idTrabajo);

                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    estado = result.ToString();
                }
            }

            return estado;
        }

        public bool EstaTrabajoEntregado(int IDTrabajo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Trabajos WHERE IdTrabajo = @IdTrabajo AND Estado = 'Entregado'";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Usar Add para especificar el tipo de datos
                        cmd.Parameters.Add("@IdTrabajo", SqlDbType.Int).Value = IDTrabajo;

                        // Ejecutar la consulta y devolver true si se encontró el trabajo como "Entregado"
                        return (int)cmd.ExecuteScalar() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones de forma adecuada
                Console.WriteLine("Error al verificar el estado del trabajo: " + ex.Message);
                return false;
            }
        }


        public bool ActualizarPrecioArreglo(int IDTrabajo, int nuevoPrecio)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    // 🔥 Combinar en una sola consulta con OUTPUT
                    string query = @"
                        UPDATE Trabajos 
                         SET PrecioArreglo = @PrecioArreglo 
                         OUTPUT inserted.Estado 
                         WHERE IdTrabajo = @IDTrabajo";

                    SqlCommand cmd = new SqlCommand(query, con, transaction);
                    cmd.Parameters.AddWithValue("@IDTrabajo", IDTrabajo);
                    cmd.Parameters.AddWithValue("@PrecioArreglo", nuevoPrecio);

                    // Obtener el estado del trabajo después de la actualización
                    object result = cmd.ExecuteScalar();

                    // Si el resultado es null (por ejemplo, si no se actualizó ninguna fila), manejarlo
                    if (result == null)
                    {
                        transaction.Rollback();
                        Console.WriteLine("No se encontró el trabajo con el ID proporcionado.");
                        return false;
                    }

                    string estado = result.ToString();

                    // ✅ Si ya está entregado, actualizar ganancias
                    if (estado == "Entregado")
                    {
                        ActualizarGananciasSemanales(nuevoPrecio, con, transaction);
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Error al actualizar el precio: " + ex.Message);
                    return false;
                }
            }
        }


        public void ActualizarGananciasPorTrabajo(int IDTrabajo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        // Obtener el precio del trabajo (ahora es un INT)
                        string queryPrecioArreglo = "SELECT PrecioArreglo FROM Trabajos WHERE IdTrabajo = @IdTrabajo";
                        int precioArreglo; // Cambié el tipo a int
                        using (SqlCommand cmdPrecio = new SqlCommand(queryPrecioArreglo, con, transaction))
                        {
                            cmdPrecio.Parameters.Add("@IdTrabajo", SqlDbType.Int).Value = IDTrabajo;
                            precioArreglo = (int)cmdPrecio.ExecuteScalar();
                        }

                        // Actualizar la ganancia semanal solo una vez
                        ActualizarGananciasSemanales(precioArreglo, con, transaction);

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error al actualizar ganancias: " + ex.Message);
                        throw;
                    }
                }
            }
        }


        private void ActualizarGananciasSemanales(int monto, SqlConnection con, SqlTransaction transaction)
        {
            DateTime hoy = DateTime.Today;
            int diaSemana = (int)hoy.DayOfWeek;
            DateTime fechaInicioSemana = hoy.AddDays(-(diaSemana == 0 ? 6 : diaSemana - 1)); // Lunes
            DateTime fechaFinSemana = fechaInicioSemana.AddDays(6); // Domingo

            string queryVerificarRegistro = @"
             SELECT IdRegistro FROM RegistroGanancias 
            WHERE FechaInicioSemana = @FechaInicio AND FechaFinSemana = @FechaFin";

            using (SqlCommand cmd = new SqlCommand(queryVerificarRegistro, con, transaction))
            {
                cmd.Parameters.Add("@FechaInicio", SqlDbType.Date).Value = fechaInicioSemana;
                cmd.Parameters.Add("@FechaFin", SqlDbType.Date).Value = fechaFinSemana;

                object idRegistro = cmd.ExecuteScalar();

                if (idRegistro != null)
                {
                    // Solo actualiza si existe el registro
                    string queryActualizarGanancia = "UPDATE RegistroGanancias SET GananciaSemanal = GananciaSemanal + @Monto WHERE IdRegistro = @IdRegistro";

                    using (SqlCommand cmdUpdate = new SqlCommand(queryActualizarGanancia, con, transaction))
                    {
                        cmdUpdate.Parameters.Add("@Monto", SqlDbType.Int).Value = monto;
                        cmdUpdate.Parameters.Add("@IdRegistro", SqlDbType.Int).Value = (int)idRegistro;
                        cmdUpdate.ExecuteNonQuery();
                    }
                }
                else
                {
                    // Inserta solo si no existe el registro
                    string queryInsertarRegistro = @"
                    INSERT INTO RegistroGanancias (FechaInicioSemana, FechaFinSemana, GananciaSemanal)
                    VALUES (@FechaInicio, @FechaFin, @Monto)";

                    using (SqlCommand cmdInsert = new SqlCommand(queryInsertarRegistro, con, transaction))
                    {
                        cmdInsert.Parameters.Add("@FechaInicio", SqlDbType.Date).Value = fechaInicioSemana;
                        cmdInsert.Parameters.Add("@FechaFin", SqlDbType.Date).Value = fechaFinSemana;
                        cmdInsert.Parameters.Add("@Monto", SqlDbType.Int).Value = monto;
                        cmdInsert.ExecuteNonQuery();
                    }
                }
            }
        }







        public int ObtenerGananciaSemanal()
        {
            int gananciaSemanal = 0;

            DateTime hoy = DateTime.Today;
            int diaSemana = (int)hoy.DayOfWeek;
            DateTime fechaInicioSemana = hoy.AddDays(-(diaSemana == 0 ? 6 : diaSemana - 1));
            DateTime fechaFinSemana = fechaInicioSemana.AddDays(6);

            string query = @"
              SELECT GananciaSemanal 
             FROM RegistroGanancias 
                WHERE FechaInicioSemana = @FechaInicio AND FechaFinSemana = @FechaFin";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date).Value = fechaInicioSemana;
                    cmd.Parameters.Add("@FechaFin", SqlDbType.Date).Value = fechaFinSemana;

                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        gananciaSemanal = Convert.ToInt32(result);
                    }
                }
            }

            return gananciaSemanal;
        }


        public bool MarcarTrabajoDevolucion(int IDTrabajo)
        {
            // Primero, verificar si el trabajo tiene un presupuesto asignado
            string verificarPresupuestoQuery = "SELECT Presupuesto FROM Trabajos WHERE IdTrabajo = @IDTrabajo";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Verificar si el trabajo tiene un presupuesto
                SqlCommand cmdVerificar = new SqlCommand(verificarPresupuestoQuery, con);
                cmdVerificar.Parameters.AddWithValue("@IDTrabajo", IDTrabajo);

                try
                {
                    con.Open();
                    var resultado = cmdVerificar.ExecuteScalar();

                    if (resultado == DBNull.Value || string.IsNullOrEmpty(resultado.ToString()))
                    {
                        // Si el presupuesto está vacío o es nulo, no se puede marcar como 'Devolución'
                        throw new Exception("El trabajo debe tener un presupuesto antes de marcarlo como 'Devolución'.");
                    }

                    // Si tiene presupuesto, se actualiza el estado a 'Devolución'
                    string query = "UPDATE Trabajos SET Estado = 'Devolucion' WHERE IdTrabajo = @IDTrabajo";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@IDTrabajo", IDTrabajo);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar el estado: " + ex.Message);
                    return false;
                }
            }
        }


        public DataTable BuscarTrabajos(string NombreBusqueda, string CategoriaBusqueda)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"
                SELECT 
                    C.ApellidoNombre AS 'Nombre del Cliente', 
                    C.Telefono AS 'Teléfono del Cliente', 
                    C.Domicilio AS 'Domicilio del Cliente', 
                    T.IdTrabajo AS 'Numero de Trabajo', 
                    T.FechaIngreso AS 'Fecha de Ingreso', 
                    E.Equipo AS 'Nombre del Equipo', 
                    E.Categoria AS 'Categoría del Equipo',
                    E.FallaDeclarada AS 'Falla Reportada', 
                    E.Modelo AS 'Modelo del Equipo', 
                    E.NumeroSerie AS 'Número de Serie', 
                    T.Estado AS 'Estado del Trabajo', 
                    E.Control AS 'Control Incluido', 
                    E.Cable AS 'Cable Incluido', 
                    E.Base AS 'Base Incluida', 
                    T.Presupuesto AS 'Presupuesto Estimado', 
                    T.PrecioArreglo AS 'Costo de Reparación' 
                FROM Clientes C 
                INNER JOIN Equipos E ON C.IdCliente = E.IdCliente 
                INNER JOIN Trabajos T ON E.IdEquipo = T.IdEquipo 
                WHERE C.ApellidoNombre COLLATE SQL_Latin1_General_CP1_CI_AS LIKE @NombreBusqueda
                AND E.Categoria COLLATE SQL_Latin1_General_CP1_CI_AS LIKE @CategoriaBusqueda
                ORDER BY T.IdTrabajo ASC"; // Ordenando por el Id del trabajo para ver los más recientes primero

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@NombreBusqueda", "%" + NombreBusqueda + "%");
                        cmd.Parameters.AddWithValue("@CategoriaBusqueda", "%" + CategoriaBusqueda + "%");

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        con.Open();
                        da.Fill(dt);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Error en la base de datos: {sqlEx.Message}", "Error de SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error general: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }











        public DataTable BuscarTrabajoID(int IdTrabajoBusqueda)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                T.IdTrabajo AS 'Numero de Trabajo',
                T.FechaIngreso AS 'Fecha de Ingreso',
                T.Estado AS 'Estado del Trabajo',
                T.Presupuesto AS 'Presupuesto Estimado',
                T.PrecioArreglo AS 'Costo de Reparación',
                T.FechaEntrega AS 'Fecha de Entrega',
                C.ApellidoNombre AS 'Cliente',
                C.Telefono AS 'Teléfono',
                C.Domicilio AS 'Domicilio',
                E.Equipo AS 'Equipo',
                E.Categoria AS 'Categoría del Equipo',
                E.FallaDeclarada AS 'Falla Reportada'
            FROM Clientes C
            INNER JOIN Equipos E ON C.IdCliente = E.IdCliente
            INNER JOIN Trabajos T ON E.IdEquipo = T.IdEquipo
            WHERE T.IdTrabajo = @IdTrabajo;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@IdTrabajo", IdTrabajoBusqueda);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }



        public DataTable ObtenerTodosLosClientes()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT 
                 IdCliente AS [ID Cliente],
                 DNI, 
                 ApellidoNombre AS [Nombre del Cliente], 
                 Telefono, 
                 Domicilio 
                  FROM Clientes";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    con.Open();
                    da.Fill(dt);
                }
            }
            return dt;
        }



        public DataTable ObtenerGanancias()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"
            SELECT 
                IdRegistro AS Registro,
                FechaInicioSemana AS [Fecha del Inicio de la Semana],
                FechaFinSemana AS [Fecha del fin de la Semana],
                GananciaSemanal AS [Ganancia de la Semana] 
            FROM RegistroGanancias";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        con.Open();
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de la excepción, puedes mostrar un mensaje o registrar el error.
                MessageBox.Show("Ocurrió un error al obtener las ganancias: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }


        public DataTable ObtenerLosEquipos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT 
                    e.IdEquipo AS 'Codigo del Equipo',
                    e.Equipo AS 'Equipo', 
                    e.Categoria AS 'Categoría del Equipo',
                    e.FallaDeclarada AS 'Falla Reportada', 
                    e.Modelo AS 'Modelo', 
                    e.NumeroSerie AS 'Número de Serie', 
                    e.Detalles AS 'Detalles del Equipo', 
                    e.Control AS 'Incluye Control', 
                    e.Cable AS 'Incluye Cable', 
                    e.Base AS 'Incluye Base' 
                    FROM Equipos e";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    con.Open();
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable ObtenerTodosLosEquipos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                e.IdEquipo AS 'Código del Equipo',
                e.Equipo AS 'Equipo', 
                e.Categoria AS 'Categoría del Equipo',
                e.FallaDeclarada AS 'Falla Reportada', 
                e.Modelo AS 'Modelo', 
                e.NumeroSerie AS 'Número de Serie', 
                e.Detalles AS 'Detalles del Equipo', 
                e.Control AS 'Incluye Control', 
                e.Cable AS 'Incluye Cable', 
                e.Base AS 'Incluye Base', 
                c.ApellidoNombre AS 'Cliente', 
                c.Telefono AS 'Teléfono', 
                c.Domicilio AS 'Domicilio'
            FROM Equipos e
            INNER JOIN Clientes c ON e.IdCliente = c.IdCliente
            ORDER BY c.ApellidoNombre, e.Equipo";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    con.Open();
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable ObtenerTodosLosTrabajos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                t.IdTrabajo AS 'Numero de Trabajo', 
                t.FechaIngreso AS 'Fecha de Ingreso', 
                t.Estado AS 'Estado del Trabajo', 
                t.Presupuesto AS 'Presupuesto Estimado', 
                t.PrecioArreglo AS 'Costo de Reparación', 
                t.FechaEntrega AS 'Fecha de Entrega',
                e.Equipo AS 'Equipo', 
                e.Modelo AS 'Modelo', 
                e.NumeroSerie AS 'Número de Serie', 
                c.ApellidoNombre AS 'Cliente', 
                c.Telefono AS 'Teléfono', 
                c.Domicilio AS 'Domicilio'
            FROM Trabajos t
            INNER JOIN Equipos e ON t.IdEquipo = e.IdEquipo
            INNER JOIN Clientes c ON e.IdCliente = c.IdCliente
            ORDER BY c.ApellidoNombre, t.FechaIngreso";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    con.Open();
                    da.Fill(dt);
                }
            }
            return dt;
        }




        public int ObtenerIdClientePorDatos(string nombre, string telefono)
        {
            int idCliente = 0; // Valor por defecto si no se encuentra

            string query = "SELECT IdCliente FROM Clientes WHERE ApellidoNombre = @Nombre AND Telefono = @Telefono";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Telefono", (object)telefono ?? DBNull.Value); // Manejo de NULL

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        idCliente = Convert.ToInt32(result);
                    }
                }
            }

            return idCliente;
        }

        public bool ValidarUsuario(string usuario, string contraseña)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @Usuario AND Contraseña = @Contraseña";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Contraseña", contraseña); // ⚠️ Luego implementaremos Hashing

                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0; // Si hay al menos un usuario con esos datos, retorna true
            }
        }


        public DataTable ObtenerTrabajosPorEstado(string estado)
        {
            DataTable dt = new DataTable();
            string query = @"
        SELECT 
            t.IdEquipo AS [Código del Equipo], 
            e.FallaDeclarada AS [Falla Declarada], 
            e.Categoria AS [Categoría del Equipo], 
            t.IdTrabajo AS [Numero de Trabajo], 
            t.Estado, 
            t.Presupuesto, 
            t.PrecioArreglo AS [Precio del Arreglo], 
            t.FechaEntrega AS [Fecha de Entrega]
        FROM Trabajos t
        INNER JOIN Equipos e ON t.IdEquipo = e.IdEquipo
        WHERE t.Estado = @Estado";

            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        // Especificar el tipo del parámetro para asegurar la compatibilidad
                        cmd.Parameters.Add("@Estado", SqlDbType.VarChar).Value = estado;

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        conexion.Open(); // Asegurarse de que la conexión se abre antes de ejecutar la consulta
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la consulta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        public DataTable ObtenerTrabajosCategoria(string categoria)
        {
            DataTable dt = new DataTable();
            string query = @"
        SELECT 
            e.Equipo AS 'Equipo', 
            e.Categoria AS 'Categoría del Equipo',
            e.FallaDeclarada AS 'Falla Reportada', 
            e.Modelo AS 'Modelo', 
            e.NumeroSerie AS 'Número de Serie', 
            e.Detalles AS 'Detalles del Equipo', 
            e.Control AS 'Incluye Control', 
            e.Cable AS 'Incluye Cable', 
            e.Base AS 'Incluye Base', 
            c.ApellidoNombre AS 'Cliente', 
            c.Telefono AS 'Teléfono', 
            c.Domicilio AS 'Domicilio'
        FROM Equipos e
        INNER JOIN Clientes c ON e.IdCliente = c.IdCliente
        WHERE e.Categoria = @Categoria
        ORDER BY c.ApellidoNombre, e.Equipo;";

            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        // Especificando explícitamente el tipo del parámetro
                        cmd.Parameters.Add("@Categoria", SqlDbType.VarChar).Value = categoria;

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        conexion.Open(); // Abrir la conexión explícitamente
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la consulta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }




        public string ObtenerTelefonoPorId(int idCliente)
        {
            string telefono = string.Empty;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Telefono FROM Clientes WHERE IdCliente = @IdCliente";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", idCliente);
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        telefono = result.ToString();
                    }
                }
            }
            return telefono;
        }




    }
}





