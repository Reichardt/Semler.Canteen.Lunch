using Semler.Canteen.Lunch.Business.Entities;
using Semler.Canteen.Lunch.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Semler.Canteen.Lunch.Infrastructure.Data
{
    public class LunchOrderMemoryRepository : ILunchOrderRepository
    {

        private List<LunchOrder> _lunchOrders = new List<LunchOrder>();


        public LunchOrder Add(LunchOrder entity)
        {
            _lunchOrders.Add(entity);
            return entity;
        }

        public void DeleteById(Guid id)
        {
            _lunchOrders.Remove(GetById(id));
        }

        public LunchOrder GetById(Guid id)
        {

            return _lunchOrders.Where(lo => lo.Id == id).First();
        }

        public IReadOnlyList<LunchOrder> ListAllByUserId(Guid id)
        {
            return _lunchOrders.Where(lo => lo.CreatedBy.Id == id).ToList().AsReadOnly();
        }
    }
}
