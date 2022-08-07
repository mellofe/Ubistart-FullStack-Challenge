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

		public TEntity Create(TEntity User)
		{
			try
			{
				DbSet.Add(User);
				Save();
				return User;
			}
			catch (Exception)
			{

				throw;
			}
		}
		public int Save()
		{
			try
			{
				return context.SaveChanges();
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
