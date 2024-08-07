// -----------------------------------------------------------------------
// <copyright file="Examen.cs" company="BANSI">
// Copyright (c) BANSI. Todos los derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace MX.BANSI.CORE.DLL.DOMAIN.Entities
{
    /// <summary>
    /// Representa un examen con su información básica.
    /// </summary>
    public class Examen
    {
        /// <summary>
        /// Obtiene o establece el identificador único del examen.
        /// </summary>
        /// <value>El identificador único del examen.</value>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del examen.
        /// </summary>
        /// <value>El nombre del examen.</value>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece la descripción del examen.
        /// </summary>
        /// <value>La descripción del examen.</value>
        public string Descripcion { get; set; }
    }
}
