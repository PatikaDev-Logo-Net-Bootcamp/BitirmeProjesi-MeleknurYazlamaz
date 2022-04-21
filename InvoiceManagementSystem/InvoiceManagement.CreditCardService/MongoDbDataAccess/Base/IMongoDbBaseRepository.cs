using InvoiceManagement.CreditCardService.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace InvoiceManagement.CreditCardService.MongoDbDataAccess.Base
{
    public interface IMongoDbBaseRepository<TEntity> where TEntity : EntityBase
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(string id);
    }
}
