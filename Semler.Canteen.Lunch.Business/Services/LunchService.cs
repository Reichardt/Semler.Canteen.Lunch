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
            if (lunchDate.Date < DateTimeOffset.Now.AddDays(2))
            {
                _logger.LogInformation("LunchOrder date does not meet 2 day in advance rule");
                throw new InvalidLunchOrderDateException();
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
            _logger.LogInformation("LunchOrder width id {id} is created", lunchOrder.Id);

            return lunchOrder;

        }


    }
}
