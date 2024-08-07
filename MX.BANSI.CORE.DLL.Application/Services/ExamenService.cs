// -----------------------------------------------------------------------
// <copyright file="ExamenService.cs" company="BANSI">
// Copyright (c) BANSI. Todos los derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace MX.BANSI.CORE.DLL.Application.Services
{
    using MX.BANSI.CORE.DLL.Application.Interfaces;
    using MX.BANSI.CORE.DLL.DOMAIN.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Proporciona la implementación de los servicios para gestionar las operaciones CRUD sobre los exámenes.
    /// </summary>
    public class ExamenService : IExamenService
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ExamenService"/>.
        /// </summary>
        /// <param name="unitOfWork">La unidad de trabajo que gestiona la persistencia de datos.</param>
        public ExamenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Obtiene de forma asincrónica todos los exámenes disponibles.
        /// </summary>
        /// <returns>Una tarea que representa una colección enumerable de todos los exámenes.</returns>
        public async Task<IEnumerable<Examen>> GetAllExamenesAsync()
        {
            return await _unitOfWork.Examenes.GetAllAsync();
        }

        /// <summary>
        /// Obtiene de forma asincrónica un examen por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del examen a obtener.</param>
        /// <returns>Una tarea que representa el examen correspondiente al identificador especificado,
        /// o <c>null</c> si no se encuentra.</returns>
        public async Task<Examen> GetExamenByIdAsync(int id)
        {
            return await _unitOfWork.Examenes.GetByIdAsync(id);
        }

        /// <summary>
        /// Crea de forma asincrónica un nuevo examen.
        /// </summary>
        /// <param name="examen">La entidad Examen que se va a crear.</param>
        /// <returns>Una tarea que representa la operación asincrónica de creación.</returns>
        public async Task CreateExamenAsync(Examen examen)
        {
            await _unitOfWork.Examenes.AddAsync(examen);
            await _unitOfWork.CompleteAsync();
        }

        /// <summary>
        /// Actualiza de forma asincrónica un examen existente.
        /// </summary>
        /// <param name="examen">La entidad Examen con los datos actualizados.</param>
        /// <returns>Una tarea que representa la operación asincrónica de actualización.</returns>
        public async Task UpdateExamenAsync(Examen examen)
        {
            await _unitOfWork.Examenes.UpdateAsync(examen);
            await _unitOfWork.CompleteAsync();
        }

        /// <summary>
        /// Elimina de forma asincrónica un examen por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del examen que se va a eliminar.</param>
        /// <returns>Una tarea que representa la operación asincrónica de eliminación.</returns>
        public async Task DeleteExamenAsync(int id)
        {
            await _unitOfWork.Examenes.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}