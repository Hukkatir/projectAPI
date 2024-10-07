using Domian.Interfaces;
using Domian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = Domian.Models.File;

namespace DataAccess.Repositories
{
    public class FileRepository : RepositoryBase<File>, IFileRepository
    {
        public FileRepository(projectDBContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
