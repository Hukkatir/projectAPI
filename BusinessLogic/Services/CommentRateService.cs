using Domian.Interfaces;
using Domian.Models;
using Domian.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class CommentRateService : ICommentRateService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CommentRateService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<CommentRate>> GetAll()
        {
            return _repositoryWrapper.CommentRate.FindAll().ToListAsync();
        }

        public Task<CommentRate> GetById(int id)
        {
            var commentRate = _repositoryWrapper.CommentRate
                .FindByCondition(x => x.CommentRateId == id).First();
            return Task.FromResult(commentRate);
        }

        public Task Create(CommentRate model)
        {
            _repositoryWrapper.CommentRate.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(CommentRate model)
        {
            _repositoryWrapper.CommentRate.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var commentRate = _repositoryWrapper.CommentRate
                .FindByCondition(x => x.CommentRateId == id).First();

            _repositoryWrapper.CommentRate.Delete(commentRate);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}
