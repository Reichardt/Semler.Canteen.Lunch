
using Semler.Canteen.Lunch.Business.Entities;
using System;
using System.Collections.Generic;

namespace Semler.Canteen.Lunch.Business.Interfaces
{
    public interface ILunchOrderRepository
    {
        LunchOrder Add(LunchOrder entity);
        LunchOrder GetById(Guid id);
        void DeleteById(Guid id);
        IReadOnlyList<LunchOrder> ListAllByUserId(Guid id);
    }
}
