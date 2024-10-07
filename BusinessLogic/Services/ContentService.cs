using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ContentService : IContentService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ContentService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<Content>> GetAll()
        {
            return _repositoryWrapper.Content.FindAll().ToListAsync();
        }

        public Task<Content> GetById(int id)
        {
            var commentRate = _repositoryWrapper.Content
                .FindByCondition(x => x.ContentId == id).First();
            return Task.FromResult(commentRate);
        }

        public Task Create(Content model)
        {
            _repositoryWrapper.Content.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(Content model)
        {
            _repositoryWrapper.Content.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var content = _repositoryWrapper.Content
                .FindByCondition(x => x.ContentId == id).First();

            _repositoryWrapper.Content.Delete(content);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}
