// -----------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="BANSI">
// Copyright (c) BANSI. Todos los derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace MX.BANSI.CORE.DLL.Application.Interfaces
{
    using MX.BANSI.CORE.DLL.DOMAIN.Entities;
    using MX.BANSI.CORE.DLL.DOMAIN.Interfaces;
    using System.Threading.Tasks;

    /// <summary>
    /// Define una interfaz para la unidad de trabajo que maneja la persistencia de datos
    /// y coordina el trabajo de los repositorios asociados.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Obtiene el repositorio para manejar las operaciones relacionadas con los exámenes.
        /// </summary>
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