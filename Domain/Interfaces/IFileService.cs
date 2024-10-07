﻿using Domian.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = Domian.Models.File;

namespace Domian.Interfaces
{
    public interface IFileService
    {
        Task<List<File>> GetAll();
        Task<File> GetById(int id);
        Task Create(File model);
        Task Update(File model);
        Task Delete(int id);
    }
}
