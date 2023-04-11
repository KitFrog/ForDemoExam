using System;
using System.Collections.Generic;
using System.Text;
using DataModels.Entities;
using System.Linq;

namespace DataModels.IRepositories
{
    public interface IMessageRep:IRepositoryRep<Message>
    {
        IQueryable<Message> Messages { get; }
    }
}
