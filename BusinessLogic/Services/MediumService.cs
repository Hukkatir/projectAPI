using Domian.Interfaces;
using Domian.Models;
using Domian.Wrapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class MediumService : IMediumService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public MediumService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<Medium>> GetAll()
        {
            return _repositoryWrapper.Medium.FindAll().ToListAsync();
        }

        public Task<Medium> GetById(int id)
        {
            var media = _repositoryWrapper.Medium
                .FindByCondition(x => x.MediaId == id).First();
            return Task.FromResult(media);
        }

        public Task Create(Medium model)
        {
            _repositoryWrapper.Medium.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(Medium model)
        {
            _repositoryWrapper.Medium.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var media = _repositoryWrapper.Medium
                .FindByCondition(x => x.MediaId == id).First();

            _repositoryWrapper.Medium.Delete(media);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}
