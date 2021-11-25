using Microsoft.EntityFrameworkCore;
using SongLyricDataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SongLyricDataAccess.Data.Repository
{
    internal class Repository<T> : IRepository<T> where T : class
    {
		protected readonly SongLyricDbContext context;
		internal DbSet<T> dbSet;

		public Repository(SongLyricDbContext context)
		{
			this.context = context;
			this.dbSet = context.Set<T>();
		}

		public void Add(T entity)
		{
			dbSet.Add(entity);
		}

		public T Find(int id)
		{
			return dbSet.Find(id);
		}

		public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, string includeProperties = null)
		{
			IQueryable<T> query = dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			if (includeProperties != null)
			{
				foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(item);
				}
			}

			if (orderby != null)
			{
				return orderby(query).ToList();
			}

			return await query.ToListAsync();
		}

		public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
		{
			IQueryable<T> query = dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			if (includeProperties != null)
			{
				foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(item);
				}
			}

			return query.FirstOrDefault();
		}

		public void Insert(T entity)
		{
			dbSet.Add(entity);
		}

		public void Update(T entity)
		{
			dbSet.Update(entity);
		}

		public void Remove(int id)
		{
			T entityToRemove = dbSet.Find(id);
			Remove(entityToRemove);
		}

		public void Remove(T entity)
		{
			dbSet.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			dbSet.RemoveRange(entities);
		}

		public async Task<int> CountAsync()
		{
			return await dbSet.CountAsync();
		}

		public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
		{
			return await dbSet.Where(expression).CountAsync();
		}
	}
}