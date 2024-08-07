// -----------------------------------------------------------------------
// <copyright file="IRepository.cs" company="BANSI">
// Copyright (c) BANSI. Todos los derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace MX.BANSI.CORE.DLL.DOMAIN.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Define un repositorio genérico para operaciones CRUD básicas.
    /// </summary>
    /// <typeparam name="T">El tipo de entidad con el que el repositorio trabajará.</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Obtiene de forma asincrónica todas las entidades del tipo <typeparamref name="T"/>.
        /// </summary>
        /// <returns>
        /// Una tarea que representa una colección enumerable de todas las entidades.
        /// </returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Obtiene de forma asincrónica una entidad del tipo <typeparamref name="T"/> por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único de la entidad a obtener.</param>
        /// <returns>
        /// Una tarea que representa la entidad correspondiente al identificador especificado,
        /// o <c>null</c> si no se encuentra.
        /// </returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Añade de forma asincrónica una nueva entidad del tipo <typeparamref name="T"/>.
        /// </summary>
        /// <param name="entity">La entidad que se va a añadir.</param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica de adición.
        /// </returns>
        Task AddAsync(T entity);

        /// <summary>
        /// Actualiza de forma asincrónica una entidad existente del tipo <typeparamref name="T"/>.
        /// </summary>
        /// <param name="entity">La entidad con los datos actualizados.</param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica de actualización.
        /// </returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Elimina de forma asincrónica una entidad del tipo <typeparamref name="T"/> por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único de la entidad que se va a eliminar.</param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica de eliminación.
        /// </returns>
        Task DeleteAsync(int id);
    }
}
