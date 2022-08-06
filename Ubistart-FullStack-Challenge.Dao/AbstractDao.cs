using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using Ubistart_FullStack_Challenge.Dao.Interfaces;
using Ubistart_FullStack_Challenge.Data.Context;

namespace Ubistart_FullStack_Challenge.Dao
{
	public class AbstractDao<TEntity> : IAbstractDao<TEntity> where TEntity : class
	{
		protected readonly SqlContext context;

		protected DbSet<TEntity> DbSet
		{
			get
			{
				return context.Set<TEntity>();
			}
		}
		public AbstractDao(SqlContext context)
		{
			this.context = context;
		}
		public TEntity Find(params object[] Keys)
		{
			try
			{
				return DbSet.Find(Keys);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public TEntity Find(Expression<Func<TEntity, bool>> where)
		{
			try
			{
				return DbSet.FirstOrDefault(where);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public TEntity Find(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, object> includes)
		{
			try
			{
				IQueryable<TEntity> _query = DbSet;

				if (includes != null)
					_query = includes(_query) as IQueryable<TEntity>;

				return _query.SingleOrDefault(predicate);
			}
			catch (Exception)
			{

				throw;
			}
		}
		public void Dispose()
		{
			try
			{
				if (context != null)
					context.Dispose();
				GC.SuppressFinalize(this);
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
