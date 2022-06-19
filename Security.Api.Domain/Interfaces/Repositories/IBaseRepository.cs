using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace Accreditation.Api.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
        IDbContextTransaction InitializeTransaction();
        void AddRange(List<TEntity> ObjList);
        void ExecuteSqlCommand(string Command);

    }
}
