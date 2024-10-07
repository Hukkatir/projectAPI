using Domian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian.Interfaces
{
    public interface IMediaFileService
    {
        Task<List<MediaFile>> GetAll();
        Task<MediaFile> GetById(int id);
        Task Create(MediaFile model);
        Task Update(MediaFile model);
        Task Delete(int id);
    }
}
