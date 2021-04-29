using Semler.Canteen.Lunch.Business.Entities;
using System;
using System.Collections.Generic;

namespace Semler.Canteen.Lunch.Business.Interfaces
{
    public interface IUserRepository
    {
        User GetById(Guid id);
        IReadOnlyList<User> ListAll();
    }
}
