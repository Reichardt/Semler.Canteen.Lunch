using Semler.Canteen.Lunch.Business.Entities;
using System;
using System.Collections.Generic;

namespace Semler.Canteen.Lunch.Business.Interfaces
{
    public interface ILocationRepository
    {
        Location GetById(Guid id);
        IReadOnlyList<Location> ListAll();
    }
}
