using ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Interfaces.Repositories;
using ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private IRepository<TEntity> _repository;

        public ServiceBase(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public void Remove(Guid id)
        {
            _repository.Remove(id);
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && (_repository != null))
            {
                _repository.Dispose();
                _repository = null;
            }
        }
    }
}
