using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IRoomsUserService
    {
        Task<List<RoomsUser>> GetAll();
        Task<RoomsUser> GetById(int idRoom, int idUser);
        Task Create(RoomsUser model);
        Task Update(RoomsUser model);
        Task Delete(int idRoom, int idUser);
    }
}
