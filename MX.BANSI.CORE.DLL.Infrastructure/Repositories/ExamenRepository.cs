// -----------------------------------------------------------------------
// <copyright file="ExamenRepository.cs" company="BANSI">
// Copyright (c) BANSI. Todos los derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace MX.BANSI.CORE.DLL.Infrastructure.Repositories
{
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using MX.BANSI.CORE.DLL.DOMAIN.Entities;
    using MX.BANSI.CORE.DLL.DOMAIN.Interfaces;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;

    /// <summary>
    /// Proporciona la implementación del repositorio para gestionar las operaciones CRUD
    /// sobre la entidad <see cref="Examen"/> usando procedimientos almacenados.
    /// </summary>
    public class ExamenRepository : IRepository<Examen>
    {
        private readonly string _connectionString;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ExamenRepository"/>.
        /// </summary>
        /// <param name="configuration">La configuración que contiene la cadena de conexión a la base de datos.</param>
        public ExamenRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Obtiene de forma asincrónica todos los exámenes disponibles.
        /// </summary>
        /// <returns>
        /// Una tarea que representa una colección enumerable de todos los exámenes.
        /// </returns>
        public async Task<IEnumerable<Examen>> GetAllAsync()
        {
            var examenes = new List<Examen>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("spConsultar", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Nombre", DBNull.Value);
                    command.Parameters.AddWithValue("@Descripcion", DBNull.Value);

                    connection.Open();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            examenes.Add(new Examen
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2)
                            });
                        }
                    }
                }
            }

            return examenes;
        }

        /// <summary>
        /// Obtiene de forma asincrónica un examen por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del examen a obtener.</param>
        /// <returns>
        /// Una tarea que representa el examen correspondiente al identificador especificado,
        /// o <c>null</c> si no se encuentra.
        /// </returns>
        public async Task<Examen> GetByIdAsync(int id)
        {
            Examen examen = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("spConsultar", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Nombre", DBNull.Value);
                    command.Parameters.AddWithValue("@Descripcion", DBNull.Value);

                    connection.Open();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            if (reader.GetInt32(0) == id)
                            {
                                examen = new Examen
                                {
                                    Id = reader.GetInt32(0),
                                    Nombre = reader.GetString(1),
                                    Descripcion = reader.GetString(2)
                                };
                                break;
                            }
                        }
                    }
                }
            }

            return examen;
        }

        /// <summary>
        /// Añade de forma asincrónica un nuevo examen.
        /// </summary>
        /// <param name="entity">La entidad <see cref="Examen"/> que se va a añadir.</param>
        /// <returns>Una tarea que representa la operación asincrónica de adición.</returns>
        public async Task AddAsync(Examen entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("spAgregar", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", entity.Id);
                    command.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", entity.Descripcion);

                    var codigoRetorno = new SqlParameter("@CodigoRetorno", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    var descripcionRetorno = new SqlParameter("@DescripcionRetorno", SqlDbType.NVarChar, 255)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(codigoRetorno);
                    command.Parameters.Add(descripcionRetorno);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();

                    var code = (int)codigoRetorno.Value;
                    var message = (string)descripcionRetorno.Value;

                    if (code != 0)
                    {
                        throw new Exception($"Error al insertar: {message}");
                    }
                }
            }
        }

        /// <summary>
        /// Actualiza de forma asincrónica un examen existente.
        /// </summary>
        /// <param name="entity">La entidad <see cref="Examen"/> con los datos actualizados.</param>
        /// <returns>Una tarea que representa la operación asincrónica de actualización.</returns>
        public async Task UpdateAsync(Examen entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("spActualizar", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", entity.Id);
                    command.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", entity.Descripcion);

                    var codigoRetorno = new SqlParameter("@CodigoRetorno", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    var descripcionRetorno = new SqlParameter("@DescripcionRetorno", SqlDbType.NVarChar, 255)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(codigoRetorno);
                    command.Parameters.Add(descripcionRetorno);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();

                    var code = (int)codigoRetorno.Value;
                    var message = (string)descripcionRetorno.Value;

                    if (code != 0)
                    {
                        throw new Exception($"Error al actualizar: {message}");
                    }
                }
            }
        }

        /// <summary>
        /// Elimina de forma asincrónica un examen por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del examen que se va a eliminar.</param>
        /// <returns>Una tarea que representa la operación asincrónica de eliminación.</returns>
        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("spEliminar", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);

                    var codigoRetorno = new SqlParameter("@CodigoRetorno", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    var descripcionRetorno = new SqlParameter("@DescripcionRetorno", SqlDbType.NVarChar, 255)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(codigoRetorno);
                    command.Parameters.Add(descripcionRetorno);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();

                    var code = (int)codigoRetorno.Value;
                    var message = (string)descripcionRetorno.Value;

                    if (code != 0)
                    {
                        throw new Exception($"Error al eliminar: {message}");
                    }
                }
            }
        }
    }
}