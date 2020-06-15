using System;
using System.Collections.Generic;

namespace IPB_Końcowy.Models
{
    public partial class Ticket
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int FlightId { get; set; }
        public int UserPersonId { get; set; }

        public virtual Flight Flight { get; set; }
        public virtual User UserPerson { get; set; }
    }
}
