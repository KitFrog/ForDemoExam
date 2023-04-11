using System;
using System.Collections.Generic;
using System.Text;
using DataModels.Entities;
using System.Linq;

namespace DataModels.IRepositories
{
    public interface IPlaceRep:IRepositoryRep<Place>
    {
        IQueryable<Place> Places { get; }
    }
}
