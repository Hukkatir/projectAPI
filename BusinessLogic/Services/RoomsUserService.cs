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
    public class RoomsUserService : IRoomsUserService
    {

        private IRepositoryWrapper _repositoryWrapper;

        public RoomsUserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<RoomsUser>> GetAll()
        {
            return _repositoryWrapper.RoomsUser.FindAll().ToListAsync();
        }

        public Task<RoomsUser> GetById(int idRoom, int idUser)
        {
            var roomsUser = _repositoryWrapper.RoomsUser
                .FindByCondition(x => x.RoomId == idRoom && x.UserId == idUser).First();
            return Task.FromResult(roomsUser);
        }

        public Task Create(RoomsUser model)
        {
            _repositoryWrapper.RoomsUser.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(RoomsUser model)
        {
            _repositoryWrapper.RoomsUser.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int idRoom, int idUser)
        {
            var roomsUser = _repositoryWrapper.RoomsUser
                .FindByCondition(x => x.RoomId == idRoom && x.UserId == idUser).First();

            _repositoryWrapper.RoomsUser.Delete(roomsUser);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}
