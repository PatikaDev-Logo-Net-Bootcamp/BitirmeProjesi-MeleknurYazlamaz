using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using InvoiceManagement.CreditCardService.Entities;

namespace InvoiceManagement.CreditCardService.MongoDbDataAccess.Base
{
    public class MongoDbBaseRepository<TEntity> : IMongoDbBaseRepository<TEntity> where TEntity : EntityBase
    {
        private IMongoCollection<TEntity> _collection;

        public MongoDbBaseRepository(IConfiguration Configuration)
        {
            IMongoDatabase database = new MongoClient(Configuration["DB:MongoDbConnectionUrl"])
                .GetDatabase(Configuration["DB:MongoDbDatabaseName"]);
            _collection = database
                .GetCollection<TEntity>(typeof(TEntity).Name + "s");
        }

        public void Insert(TEntity entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            _collection.InsertOne(entity);

        }
        public void Update(TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq("Id", entity.Id);

            var updateDefination = new List<UpdateDefinition<TEntity>>();
            foreach (var dataField in typeof(TEntity).GetProperties())
            {
                if (dataField.GetValue(entity) != null)
                {
                    updateDefination.Add(Builders<TEntity>.Update.Set(dataField.Name, dataField.GetValue(entity)));
                }

            }
            var combinedUpdate = Builders<TEntity>.Update.Combine(updateDefination);

            _collection.UpdateOne(filter, combinedUpdate);

        }
        public void Delete(TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq("Id", entity.Id);
            _collection.DeleteOne(filter);

        }
        public IEnumerable<TEntity>
            SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return _collection
                .AsQueryable<TEntity>()
                .Where(predicate.Compile());
        }
        public IEnumerable<TEntity> GetAll()
        {
            var result = _collection.Find(Builders<TEntity>.Filter.Empty).ToList();

            return result;
        }
        public TEntity GetById(string id)
        {
            var filter = Builders<TEntity>.Filter.Eq("Id", id);
            var result = _collection.Find(filter).FirstOrDefault();
            return result;
        }
    }
}
