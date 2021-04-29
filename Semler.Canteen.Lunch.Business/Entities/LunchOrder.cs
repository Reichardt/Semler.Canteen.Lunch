using System;

namespace Semler.Canteen.Lunch.Business.Entities
{
    public class LunchOrder
    {

        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Location Location { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? ModifiedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }

        public User CreatedBy { get; set; }
        public User? ModifiedBy { get; set; }
        public User? DeletedBy { get; set; }

    }
}
