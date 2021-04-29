using Semler.Canteen.Lunch.Business.Entities;
using Semler.Canteen.Lunch.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Semler.Canteen.Lunch.Infrastructure.Data
{
    public class LocationMemoryRepository : ILocationRepository
    {

        private List<Location> _locations = new List<Location>
            {
                new Location { Id = Guid.NewGuid(), Name = "Park Allé 350, 2605 Brøndby"},
                new Location { Id = Guid.NewGuid(), Name = "Park Allé 355, 2605 Brøndby"},
                new Location { Id = Guid.NewGuid(), Name = "Park Allé 356, 2605 Brøndby"},
                new Location { Id = Guid.NewGuid(), Name = "Banemarksvej 4, 2605 Brøndby"},
                new Location { Id = Guid.NewGuid(), Name = "Banemarksvej 16, 2605 Brøndby"}
            };

        public Location GetById(Guid id)
        {
            return _locations.Where(location => location.Id == id).First();
        }

        public IReadOnlyList<Location> ListAll()
        {
            return _locations.AsReadOnly();
        }
    }
}
