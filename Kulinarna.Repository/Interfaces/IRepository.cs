﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore.Query;

namespace Kulinarna.Repository.Interfaces
{
    public interface IRepository<T> //T to jeden z modeli
    {
		IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes);
		IEnumerable<T> GetAll(Expression<Func<T, object>> include, Expression<Func<object, object>> nestedInclude, int pageIndex = 0, int pageSize = 0);
		IEnumerable<T> GetAllBy(Expression<Func<T, bool>> getBy, params Expression<Func<T, object>>[] includes);
		IEnumerable<T> GetAllBy(Expression<Func<T, bool>> getBy, Expression<Func<T, object>> include = null, Expression<Func<object, object>> nestedInclude = null, int pageIndex = 0, int pageSize = 0);
		T GetBy(Expression<Func<T, bool>> getBy, params Expression<Func<T, object>>[] includes);
		T GetBy(Expression<Func<T, bool>> getBy, Expression<Func<T, object>> include, Expression<Func<object, object>> nestedInclude);
		bool Exists(Expression<Func<T, bool>> expression);
		void Insert(T entity);
		void Update(T entity);
		void Delete(Expression<Func<T, bool>> expression);
		void Delete(T entity);
		void GetRelatedCollections(T entity, params Expression<Func<T, IEnumerable<object>>>[] collections);
		void GetRelatedCollectionsWithObject<TInclude>(T entity, Expression<Func<T, IEnumerable<TInclude>>> collection, Expression<Func<TInclude, object>> include) where TInclude : class;
	}
}
