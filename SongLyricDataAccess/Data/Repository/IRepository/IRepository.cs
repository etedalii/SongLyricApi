using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SongLyricDataAccess.Data.Repository.IRepository
{
	public interface IRepository<T> where T : class
	{
		T Find(int id);
		Task<T> FindAsync(int id);

		Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null,Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,string includeProperties = null);

		T GetFirstOrDefault(Expression<Func<T, bool>> filter = null,string includeProperties = null);

		void Insert(T entity);
		
		void Update(T entity);
		
		void Remove(int id);
		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entities);

		Task<int> CountAsync();
		Task<int> CountAsync(Expression<Func<T, bool>> expression);

		bool Any(Expression<Func<T, bool>> expression);
		Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
	}
}