using System;
using System.Collections.Generic;
using System.Linq;

namespace ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
    }
}
