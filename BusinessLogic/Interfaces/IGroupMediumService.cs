using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IGroupMediumService 
    {
        Task<List<GroupMedium>> GetAll();
        Task<GroupMedium> GetById(int id);
        Task Create(GroupMedium model);
        Task Update(GroupMedium model);
        Task Delete(int id);
    }
}
