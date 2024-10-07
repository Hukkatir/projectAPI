using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ICommentRateService
    {
        Task<List<CommentRate>> GetAll();
        Task<CommentRate> GetById(int id);
        Task Create(CommentRate model);
        Task Update(CommentRate model);
        Task Delete(int id);
    }
}
