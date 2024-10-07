using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IRoomService
    {
        Task<List<Room>> GetAll();
        Task<Room> GetById(int id);
        Task Create(Room model);
        Task Update(Room model);
        Task Delete(int id);
    }
}
