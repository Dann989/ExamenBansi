// -----------------------------------------------------------------------
// <copyright file="UnitOfWork.cs" company="BANSI">
// Copyright (c) BANSI. Todos los derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace MX.BANSI.CORE.DLL.Infrastructure
{
    using MX.BANSI.CORE.DLL.DOMAIN.Entities;
    using MX.BANSI.CORE.DLL.DOMAIN.Interfaces;
    using MX.BANSI.CORE.DLL.Application.Interfaces;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementación de la unidad de trabajo para gestionar la persistencia de datos
    /// y coordinar las operaciones de los repositorios asociados.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRepository<Examen> _examenRepository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UnitOfWork"/>.
        /// </summary>
        /// <param name="examenRepository">El repositorio que maneja las operaciones relacionadas con los exámenes.</param>
        public UnitOfWork(IRepository<Examen> examenRepository)
        {
            _examenRepository = examenRepository;
        }

        /// <summary>
        /// Obtiene el repositorio para manejar las operaciones relacionadas con los exámenes.
        /// </summary>
        /// <value>El repositorio de exámenes.</value>
        public IRepository<Examen> Examenes => _examenRepository;

        /// <summary>
        /// Guarda de forma asincrónica todos los cambios realizados en el contexto de la base de datos.
        /// </summary>
        /// <returns>
        /// Una tarea que representa la operación asincrónica, con el número de entidades afectadas.
        /// </returns>
        public async Task<int> CompleteAsync()
        {
            // Implementa la lógica para guardar cambios en la base de datos aquí.
            // Actualmente devuelve 0 como un placeholder.
            return await Task.FromResult(0);
        }
    }
}