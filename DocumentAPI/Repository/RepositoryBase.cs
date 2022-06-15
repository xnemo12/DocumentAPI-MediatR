﻿using DocumentAPI.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace DocumentAPI.Repository
{
    public  class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
		public RepositoryContext RepositoryContext;

		public RepositoryBase(RepositoryContext repositoryContext)
			=> RepositoryContext = repositoryContext;

		public IQueryable<T> FindAll() => RepositoryContext.Set<T>().AsNoTracking();

		public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
		{
			return RepositoryContext.Set<T>().Where(expression).AsNoTracking();
		}

		public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);

		public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);

		public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
	}
}
