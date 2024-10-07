using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = DataAccess.Models.File;

namespace BusinessLogic.Services
{
    public class FileService : IFileService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public FileService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<File>> GetAll()
        {
            return _repositoryWrapper.Files.FindAll().ToListAsync();
        }

        public Task<File> GetById(int id)
        {
            var f = _repositoryWrapper.Files
                .FindByCondition(x => x.FileId == id).First();
            return Task.FromResult(f);
        }

        public Task Create(File model)
        {
            _repositoryWrapper.Files.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(File model)
        {
            _repositoryWrapper.Files.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var f = _repositoryWrapper.Files
                .FindByCondition(x => x.FileId == id).First();

            _repositoryWrapper.Files.Delete(f);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}

