// -----------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="BANSI">
// Copyright (c) BANSI. Todos los derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Application.Interfaces
{
    using MX.BANSI.CORE.DLL.DOMAIN.Entities;
    using MX.BANSI.CORE.DLL.DOMAIN.Interfaces;
    using System.Threading.Tasks;

    /// <summary>
    /// Define una interfaz para la unidad de trabajo que gestiona la persistencia de datos
    /// y coordina el trabajo de los repositorios asociados.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Obtiene el repositorio para manejar las operaciones relacionadas con los exámenes.
        /// </summary>
        /// <value>El repositorio de exámenes.</value>
        IRepository<Examen> Examenes { get; }

        /// <summary>
        /// Guarda de forma asincrónica todos los cambios realizados en el contexto de la base de datos.
        /// </summary>
        /// <returns>
        /// Una tarea que representa la operación asincrónica, con el número de entidades afectadas.
        /// </returns>
        Task<int> CompleteAsync();
    }
}