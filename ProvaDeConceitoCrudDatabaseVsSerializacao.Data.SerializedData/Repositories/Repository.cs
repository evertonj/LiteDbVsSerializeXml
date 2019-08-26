using ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Interfaces;
using ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Interfaces.Repositories;
using ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Models;
using System;
using System.Collections.Generic;

namespace ProvaDeConceitoCrudDatabaseVsSerializacao.Data.SerializedData.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Base
    {
        public List<TEntity> Entities { get; set; }
        public SerializedDataContext<TEntity> Db { get; set; } = new SerializedDataContext<TEntity>();

        public Repository()
        {
            Entities = Db.ReadXML();
            if (Entities == null)
                Entities = new List<TEntity>();
        }

        public void Add(TEntity obj)
        {
            Entities.Add(obj);
            Db.WriteXML(Entities);
        }

        public TEntity GetById(Guid id)
        {
            return Db.ReadXML().Find(x => x.Id == id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.ReadXML();
        }

        public void Update(TEntity obj)
        {
            var result = Entities.Find(x => x.Id == obj.Id);
            Entities.Remove(result);
            Entities.Add(obj);
            Db.WriteXML(Entities);
        }

        public void Remove(Guid id)
        {
            var result = Entities.Find(x => x.Id == id);
            Entities.Remove(result);
            Db.WriteXML(Entities);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && (Db != null))
            {
                Db = null;
                Entities = null;
            }
        }
    }
}
