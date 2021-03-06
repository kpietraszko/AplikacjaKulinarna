﻿using Kulinarna.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Kulinarna.Repository
{
	public class Repository<T> : IRepository<T> where T : class //where T:BaseModel
	{
		private readonly ApplicationDbContext _context;
		private DbSet<T> _dbSet;

		public Repository(ApplicationDbContext context)
		{
			_context = context;
			_dbSet = context.Set<T>();
		}

		public bool Exists(Expression<Func<T, bool>> expression)
		{
			return _dbSet.Any(expression);
		}

		public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes)
		{
			IQueryable<T> query = _dbSet;
			foreach (var include in includes)
			{
				query = query.Include(include);
			}
			return query;
		}

		public IEnumerable<T> GetAllBy(Expression<Func<T, bool>> getBy, params Expression<Func<T, object>>[] includes)
		{
			IQueryable<T> query = _dbSet;
			foreach (var include in includes)
			{
				query = query.Include(include);
			}
			var result = query.Where(getBy);
			return result;
		}

		public IEnumerable<T> GetAll(Expression<Func<T, object>> include, Expression<Func<object, object>> nestedInclude,
			int pageIndex = 0, int pageSize = 0)
		{
			IQueryable<T> query = _dbSet;
			query = query.Skip(pageIndex * pageSize).Include(include).ThenInclude(nestedInclude);
			if (pageSize > 0)
			{
				query = query.Take(pageSize);
			}
			return query;
		}

		public IEnumerable<T> GetAllBy(Expression<Func<T, bool>> getBy, Expression<Func<T, object>> include,
			Expression<Func<object, object>> nestedInclude, int pageIndex, int pageSize)
		{
			if (pageSize == 0)
			{
				pageSize = int.MaxValue;
			}
			IQueryable<T> query = _dbSet;
			if (include != null)
			{
				query = query.Include(include);
				if (nestedInclude != null)
				{
					query = ((IIncludableQueryable<T, object>)query).ThenInclude(nestedInclude);
				}
			}
			return query.Where(getBy).Skip(pageIndex * pageSize).Take(pageSize).ToArray();
		}

		public T GetBy(Expression<Func<T, bool>> getBy, params Expression<Func<T, object>>[] includes)
		{
			IQueryable<T> query = _dbSet;
			foreach (var include in includes)
			{
				query = query.Include(include);
			}
			var result = query.FirstOrDefault(getBy);
			return result;
		}
		//Expression<Func<object, object>> nestedInclude
		public T GetBy(Expression<Func<T, bool>> getBy, Expression<Func<T, object>> include, Expression<Func<object, object>> nestedInclude)
		{
			IQueryable<T> query = _dbSet;
			query = query.Include(include).ThenInclude(nestedInclude);
			var result = query.FirstOrDefault(getBy);
			return result;
		}

		public void Insert(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException("entity");
			}
			_dbSet.Add(entity);
			_context.SaveChanges();
		}

		public void Update(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException("entity");
			}
			_dbSet.Update(entity);
			_context.SaveChanges();
		}

		public void Update<U>(U entity, U newValues) where U : class //nie dziala dla modeli mających kolekcje
		{
			if (entity == null)
			{
				throw new ArgumentNullException("entity");
			}
			_context.Entry(entity).CurrentValues.SetValues(newValues);
			_context.SaveChanges();
		}

		public void Delete(Expression<Func<T, bool>> expression)
		{
			var entity = _dbSet.SingleOrDefault(expression);
			if (entity == null)
			{
				throw new NullReferenceException();
			}
			_dbSet.Remove(entity);
			_context.SaveChanges();
		}
		public void Delete(T entity)
		{
			if (entity == null)
			{
				throw new NullReferenceException();
			}
			_dbSet.Remove(entity);
			_context.SaveChanges();
		}
		public void GetRelatedCollections(T entity, params Expression<Func<T, IEnumerable<object>>>[] collections)
		{
			foreach (var collection in collections)
			{
				_context.Entry(entity).Collection(collection).Load();
			}
		}
		public void GetRelatedCollectionsWithObject<TInclude>(T entity, Expression<Func<T, IEnumerable<TInclude>>> collection, Expression<Func<TInclude, object>> include) where TInclude : class
		{
			_context.Entry(entity).Collection(collection).Query().Include(include).Load();

		}
	}
}
