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
    public class MediaFileService : IMediaFileService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public MediaFileService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<MediaFile>> GetAll()
        {
            return _repositoryWrapper.MediaFile.FindAll().ToListAsync();
        }

        public Task<MediaFile> GetById(int id)
        {
            var mediafile = _repositoryWrapper.MediaFile
                .FindByCondition(x => x.MediaFileId == id).First();
            return Task.FromResult(mediafile);
        }

        public Task Create(MediaFile model)
        {
            _repositoryWrapper.MediaFile.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(MediaFile model)
        {
            _repositoryWrapper.MediaFile.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var mediafile = _repositoryWrapper.MediaFile
                .FindByCondition(x => x.MediaFileId == id).First();

            _repositoryWrapper.MediaFile.Delete(mediafile);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}

