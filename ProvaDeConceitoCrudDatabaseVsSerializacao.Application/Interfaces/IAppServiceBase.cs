using System;
using System.Collections.Generic;

namespace ProvaDeConceitoCrudDatabaseVsSerializacao.Application.Interfaces
{
    public interface IAppServiceBase<TEntity>: IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
    }
}
