﻿using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class RoomsUserRepository : RepositoryBase<RoomsUser>, IRoomsUserRepository
    {
        public RoomsUserRepository(projectDBContext repositoryContext)
            : base(repositoryContext)
        {
        }

    }
}
