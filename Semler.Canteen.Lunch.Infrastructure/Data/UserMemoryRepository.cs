using Semler.Canteen.Lunch.Business.Entities;
using Semler.Canteen.Lunch.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Semler.Canteen.Lunch.Infrastructure.Data
{
    public class UserMemoryRepository: IUserRepository
    {
        private List<User> _users = new List<User>
            {
                new User { Id = Guid.NewGuid(), FirstName = "Hans", LastName = "Hansen", Email = "hans@hansen.dk" },
                new User { Id = Guid.NewGuid(), FirstName = "Peter", LastName = "Petersen", Email = "peter@petersen.dk" },
                new User { Id = Guid.NewGuid(), FirstName = "Jacob", LastName = "Jacobsen", Email = "jacob@jacobsen.dk" },
                new User { Id = Guid.NewGuid(), FirstName = "Morten", LastName = "Mortensen", Email = "morten@mortensen.dk" },
                new User { Id = Guid.NewGuid(), FirstName = "Mads", LastName = "Madsen", Email = "mads@madsen.dk" }
            };

        public User GetById(Guid id)
        {
            return _users.Where(user => user.Id == id).First();
        }

        public IReadOnlyList<User> ListAll()
        {
            return _users.AsReadOnly();
        }
    }
}
