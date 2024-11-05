using Microsoft.EntityFrameworkCore;
using Datos.Repositorio.IRepositorio;
using System.Linq.Expressions;
using Microsoft.IdentityModel.Tokens;

namespace Datos.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> _dbSet;

        public Repositorio(ApplicationDbContext context)
        {
            _context = context;
            this._dbSet = _context.Set<T>();
        }

        public void Agregar(T entidad)
        {
            _dbSet.Add(entidad);
        }

        public T Obtener(int id)
        {
            return _dbSet.Find(id);
        }

        public T ObtenerPrimero(Expression<Func<T, bool>> filtro, List<string> propiedadesAIncluir, bool seguirCambios = true)
        {
            IQueryable<T> query = _dbSet;

            if (filtro != null)
            {
                query = query.Where(filtro);
            }

            if (!propiedadesAIncluir.IsNullOrEmpty())
            {
                foreach (string propiedad in propiedadesAIncluir)
                {
                    query = query.Include(propiedad);
                }
            }

            if (!seguirCambios)
            {
                query = query.AsNoTracking();
            }

            return query.First();
        }

        public IEnumerable<T> ObtenerTodos(Expression<Func<T, bool>> filtro, Func<IQueryable<T>, IOrderedQueryable<T>> ordenarPor, List<string> propiedadesAIncluir, bool seguirCambios = true)
        {
            IQueryable<T> query = _dbSet;

            if (filtro != null)
            {
                query = query.Where(filtro);
            }

            if (!propiedadesAIncluir.IsNullOrEmpty())
            {
                foreach (string propiedad in propiedadesAIncluir)
                {
                    query = query.Include(propiedad);
                }
            }

            if (ordenarPor != null)
            {
                query = ordenarPor(query);
            }

            if (!seguirCambios)
            {
                query = query.AsNoTracking();
            }

            return query.ToList();
        }

        public void Remover(T entidad)
        {
            _dbSet.Remove(entidad);
        }

        public void RemoverRango(IEnumerable<T> entidades)
        {
            _dbSet.RemoveRange(entidades);
        }

        public void GuardarCambios()
        {
            _context.SaveChanges();
        }
    }
}
