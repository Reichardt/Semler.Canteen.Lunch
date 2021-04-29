using Microsoft.AspNetCore.Mvc.Rendering;
using Semler.Canteen.Lunch.Business.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Semler.Canteen.Lunch.Web.Models
{
    public class IndexViewModel
    {
        [Required]
        public Guid? LocationId { get; set; }
        [Required]
        public DateTime? Date { get; set; } = DateTime.Now;

        public List<SelectListItem> LocationSelectListItems { get; set; }

        public IReadOnlyList<LunchOrder> LunchOrders { get; set; }

        public static List<SelectListItem> GetLocationListItems(IReadOnlyList<Location> locations)
        {
            return locations
                .Select(location => new SelectListItem {
                    Value = location.Id.ToString(),
                    Text = location.Name
                })
                .ToList();
        }

    }
}