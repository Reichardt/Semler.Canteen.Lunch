using Microsoft.AspNetCore.Mvc.Rendering;
using Semler.Canteen.Lunch.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semler.Canteen.Lunch.Web.Models.User
{
    public class LoginViewModel
    {
        public List<SelectListItem> UserSelectListItems { get; }

        public LoginViewModel(IReadOnlyList<Business.Entities.User> users)
        {
            UserSelectListItems = users.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Fullname }).ToList();
        }
    }
}
