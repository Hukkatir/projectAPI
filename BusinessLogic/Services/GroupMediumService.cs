using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
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
    public class GroupMediumService : IGroupMediumService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public GroupMediumService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<GroupMedium>> GetAll()
        {
            return _repositoryWrapper.GroupMedium.FindAll().ToListAsync();
        }

        public Task<GroupMedium> GetById(int id)
        {
            var groupMedium = _repositoryWrapper.GroupMedium
                .FindByCondition(x => x.GroupId == id).First();
            return Task.FromResult(groupMedium);
        }

        public Task Create(GroupMedium model)
        {
            _repositoryWrapper.GroupMedium.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(GroupMedium model)
        {
            _repositoryWrapper.GroupMedium.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var groupMedium = _repositoryWrapper.GroupMedium
                .FindByCondition(x => x.GroupId == id).First();

            _repositoryWrapper.GroupMedium.Delete(groupMedium);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}
