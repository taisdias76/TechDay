﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MinasBank.Shared.Data
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        //método para fazer a adição
        ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity, CancellationToken cancellationToken);

        //método para fazer atualizar 
        void Update(TEntity entity);

        //método para deletar
        void Delete(TEntity entity);

        //método para obter pelo ID
        ValueTask<TEntity> GetByKeysAsync(CancellationToken cancellationToken, params object[] keys);

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            bool noTracking = false, int? take = null, int? skip = null);

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            bool noTracking = false, int? take = null, int? skip = null,
            CancellationToken cancellationToken = default);
        Task<bool> CommitAsync(CancellationToken cancellationToken);
    }
}
