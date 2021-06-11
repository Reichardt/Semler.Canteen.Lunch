using Microsoft.Extensions.Logging;
using Semler.Canteen.Lunch.Business.Entities;
using Semler.Canteen.Lunch.Business.Exceptions;
using Semler.Canteen.Lunch.Business.Interfaces;
using System;

namespace Semler.Canteen.Lunch.Business.Services
{
    public class LunchService
    {

        private readonly ILogger<LunchService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly ILunchOrderRepository _lunchOrderRepository;

        public LunchService(ILogger<LunchService> logger, IUserRepository userRepository, ILocationRepository locationRepository, ILunchOrderRepository lunchOrderRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _locationRepository = locationRepository;
            _lunchOrderRepository = lunchOrderRepository;
        }

        public LunchOrder AddLunchOrder(Guid userId, Guid locationId, DateTime lunchDate)
        {
            if (lunchDate.Date.DayOfWeek == DayOfWeek.Saturday || lunchDate.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                _logger.LogInformation("LunchOrder date does not meet 2 day in advance rule");
                throw new InvalidLunchOrderDateException("Du kan ikke bestille frokost lørdag og søndag..");
            } else if (lunchDate.Date < DateTimeOffset.Now.AddDays(2))
            {
                _logger.LogInformation("LunchOrder date does not meet no weekend orders rule");
                throw new InvalidLunchOrderDateException("Din bestilling skal foretages mindst 2 dage før ønskede frokost dato...");
            }

            foreach (LunchOrder lunch in _lunchOrderRepository.ListAllByUserId(userId) )
            {
                if(lunch.Date == lunchDate)
                {
                    _logger.LogInformation("LunchOrder date does not meet no double orders rule");
                    throw new InvalidLunchOrderDateException($"Du har allerede bestilt frokost d. {lunchDate.Date.ToShortDateString()}");
                }
            }

            var user = _userRepository.GetById(userId);
            var location = _locationRepository.GetById(locationId);

            var lunchOrder = new LunchOrder
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                CreatedBy = user,
                Date = lunchDate,
                Location = location
            };

            _lunchOrderRepository.Add(lunchOrder);
            _logger.LogInformation("LunchOrder with id {id} is created", lunchOrder.Id);

            return lunchOrder;

        }

        public void RemoveLunchOrderById(Guid id)
        {
            _lunchOrderRepository.DeleteById(id);
            _logger.LogInformation("LunchOrder with id {id} was deleted", id);
        }


    }
}
