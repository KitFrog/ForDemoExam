using System;
using System.Collections.Generic;
using System.Text;
using DataModels.Entities;
using System.Linq;

namespace DataModels.IRepositories
{
    public interface IEventRep:IRepositoryRep<Event>
    {
        IQueryable<Event> Events { get; }
    }
}
