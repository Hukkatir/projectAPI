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
    public class MessagesUserService : IMessagesUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public MessagesUserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<MessagesUser>> GetAll()
        {
            return _repositoryWrapper.MessagesUser.FindAll().ToListAsync();
        }

        public Task<MessagesUser> GetById(int id)
        {
            var messagesUser = _repositoryWrapper.MessagesUser
                .FindByCondition(x => x.MessageId == id).First();
            return Task.FromResult(messagesUser);
        }

        public Task Create(MessagesUser model)
        {
            _repositoryWrapper.MessagesUser.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(MessagesUser model)
        {
            _repositoryWrapper.MessagesUser.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var messagesUser = _repositoryWrapper.MessagesUser
                .FindByCondition(x => x.MessageId == id).First();

            _repositoryWrapper.MessagesUser.Delete(messagesUser);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}
