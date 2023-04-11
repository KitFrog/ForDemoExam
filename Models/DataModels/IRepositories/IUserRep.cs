using DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModels.IRepositories
{
    public interface IUserRep:IRepositoryRep<User>
    {
        IQueryable<User> Users { get; }
    }
}
