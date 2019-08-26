using LiteDB;
using ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace ProvaDeConceitoCrudDatabaseVsSerializacao.Data.Database.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected LiteCollection<TEntity> LiteCollection;

        public Repository()
        {
            LiteCollection = LiteDataBaseContext.GetDatabase().GetCollection<TEntity>();
        }

        public void Add(TEntity obj)
        {
            LiteCollection.Insert(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return LiteCollection.FindAll();
        }

        public TEntity GetById(Guid id)
        {
            return LiteCollection.FindById(new BsonValue(id));
        }

        public void Remove(Guid id)
        {
            LiteCollection.Delete(new BsonValue(id));
        }

        public void Update(TEntity obj)
        {
            LiteCollection.Update(obj);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && (LiteCollection != null))
            {
                LiteCollection = null;
            }
        }
    }
}
