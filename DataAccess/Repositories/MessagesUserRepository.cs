﻿using Domian.Interfaces;
using Domian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class MessagesUserRepository : RepositoryBase<MessagesUser>, IMessagesUserRepository
    {
        public MessagesUserRepository(projectDBContext repositoryContext)
            : base(repositoryContext)
        { 
        }
    } 
    
}
