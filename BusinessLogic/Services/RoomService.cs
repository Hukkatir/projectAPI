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
    public class RoomService : IRoomService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public RoomService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<Room>> GetAll()
        {
            return _repositoryWrapper.Room.FindAll().ToListAsync();
        }

        public Task<Room> GetById(int id)
        {
            var room = _repositoryWrapper.Room
                .FindByCondition(x => x.RoomId == id).First();
            return Task.FromResult(room);
        }

        public Task Create(Room model)
        {
            _repositoryWrapper.Room.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(Room model)
        {
            _repositoryWrapper.Room.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var room = _repositoryWrapper.Room
                .FindByCondition(x => x.RoomId == id).First();

            _repositoryWrapper.Room.Delete(room);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}
