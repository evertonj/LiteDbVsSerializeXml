using ProvaDeConceitoCrudDatabaseVsSerializacao.Application.Interfaces;
using ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace ProvaDeConceitoCrudDatabaseVsSerializacao.Application
{
    public class AppServiceBase<TEntity> : IAppServiceBase<TEntity> where TEntity : class
    {
        private IServiceBase<TEntity> _repositoryService;

        public AppServiceBase(IServiceBase<TEntity> repositoryService)
        {
            _repositoryService = repositoryService;
        }

        public void Add(TEntity obj)
        {
            _repositoryService.Add(obj);
        }


        public IEnumerable<TEntity> GetAll()
        {
            return _repositoryService.GetAll();
        }

        public TEntity GetById(Guid id)
        {
            return _repositoryService.GetById(id);
        }

        public void Remove(Guid id)
        {
            _repositoryService.Remove(id);
        }

        public void Update(TEntity obj)
        {
            _repositoryService.Update(obj);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing && _repositoryService != null)
            {
                _repositoryService.Dispose();
                _repositoryService = null;
            }
        }
    }
}
