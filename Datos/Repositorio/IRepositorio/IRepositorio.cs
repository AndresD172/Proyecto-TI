using System.Linq.Expressions;

namespace Datos.Repositorio.IRepositorio
{
    public interface IRepositorio<T> where T : class
    {
        /// <summary>
        /// Agrega una entidad <typeparamref name="T"/> a la base de datos.
        /// </summary>
        /// <param name="entidad">Entidad a almacenar.</param>
        void Agregar(T entidad);

        /// <summary>
        /// Obtiene la entidad de la base de datos qur corresponde con el ID dado.
        /// </summary>
        /// <param name="id">ID de la entidad.</param>
        /// <returns><see cref="T"/> cuando se obtiene un resultado; de lo contrario, <c>null</c>.</returns>
        T? Obtener(int id);

        /// <summary>
        /// Obtiene una colección de entidades de la base de datos. 
        /// </summary>
        /// <param name="filtro">Filtro opcional a aplicar a la consulta. Si es nula, no se aplicará el filtrado.</param>
        /// <param name="ordenarPor">Función opcional que especifica el orden de los resultados. Si es nula, no se aplicará el ordenamiento.</param>
        /// <param name="propiedadesAIncluir">
        /// Lista de propiedades relacionadas a la entidad a incluir en la consulta. El nombre de propiedad a incluir debe coincidir con el nombre de la propiedad establecido en la entidad.
        /// </param>
        /// <param name="seguirCambios">
        /// Indica si el seguimiento de cambios deberá ser activado o no. El valor por defecto es <c>true</c>.
        /// </param>
        /// <returns>
        /// Un colección <see cref="IEnumerable{T}"/> con los resultados obtenidos.
        /// </returns>
        IEnumerable<T> ObtenerTodos(
            Expression<Func<T, bool>>? filtro = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? ordenarPor = null,
            List<string>? propiedadesAIncluir = null,
            bool seguirCambios = true
        );

        /// <summary>
        /// Obtiene la primera entidad almacenada en la base de datos.
        /// </summary>
        /// <param name="filtro">Filtro opcional a aplicar a la consulta. Si es nula, no se aplicará el filtrado.</param>
        /// <param name="propiedadesAIncluir">
        /// Lista de propiedades relacionadas a la entidad a incluir en la consulta. El nombre de propiedad a incluir debe coincidir con el nombre de la propiedad establecido en la entidad.
        /// </param>
        /// <param name="seguirCambios">
        /// Indica si el seguimiento de cambios deberá ser activado o no. El valor por defecto es <c>true</c>.
        /// </param>
        /// <returns>
        /// La primera entidad en la base de datos.
        /// </returns>
        T? ObtenerPrimero(
            Expression<Func<T, bool>>? filtro = null,
            List<string>? propiedadesAIncluir = null,
            bool seguirCambios = true
        );

        /// <summary>
        /// Remueve una entidad de la base de datos.
        /// </summary>
        /// <param name="entidad">Entidad a remover.</param>
        void Remover(T entidad);

        /// <summary>
        /// Remueve una lista de entidades de la base de datos.
        /// </summary>
        /// <param name="entidades">Listado de entidades a remover.</param>
        void RemoverRango(IEnumerable<T> entidades);

        /// <summary>
        /// Escribe todos los cambios realizados en la base de datos.
        /// </summary>
        void GuardarCambios();
    }
}
