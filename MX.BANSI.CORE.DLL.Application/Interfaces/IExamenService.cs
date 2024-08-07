// -----------------------------------------------------------------------
// <copyright file="IExamenService.cs" company="BANSI">
// Copyright (c) BANSI. Todos los derechos reservados.
// </copyright>
// -----------------------------------------------------------------------
namespace MX.BANSI.CORE.DLL.Application.Interfaces
{
    using MX.BANSI.CORE.DLL.DOMAIN.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Proporciona métodos para gestionar las operaciones CRUD sobre la entidad Examen.
    /// </summary>
    public interface IExamenService
    {
        /// <summary>
        /// Obtiene todos los exámenes disponibles.
        /// </summary>
        /// <returns>
        /// Una tarea que representa una colección enumerable de todos los exámenes.
        /// </returns>
        Task<IEnumerable<Examen>> GetAllExamenesAsync();

        /// <summary>
        /// Obtiene un examen por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del examen a obtener.</param>
        /// <returns>
        /// Una tarea que representa el examen correspondiente al identificador especificado,
        /// o <c>null</c> si no se encuentra.
        /// </returns>
        Task<Examen> GetExamenByIdAsync(int id);

        /// <summary>
        /// Crea un nuevo examen.
        /// </summary>
        /// <param name="examen">La entidad Examen que se va a crear.</param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica de creación.
        /// </returns>
        Task CreateExamenAsync(Examen examen);

        /// <summary>
        /// Actualiza un examen existente.
        /// </summary>
        /// <param name="examen">La entidad Examen con los datos actualizados.</param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica de actualización.
        /// </returns>
        Task UpdateExamenAsync(Examen examen);

        /// <summary>
        /// Elimina un examen por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del examen que se va a eliminar.</param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica de eliminación.
        /// </returns>
        Task DeleteExamenAsync(int id);
    }
}
