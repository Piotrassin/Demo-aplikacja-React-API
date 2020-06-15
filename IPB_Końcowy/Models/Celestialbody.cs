using System;
using System.Collections.Generic;

namespace IPB_Końcowy.Models
{
    public partial class Celestialbody
    {
        public Celestialbody()
        {
            FlightArrBody = new HashSet<Flight>();
            FlightDepBody = new HashSet<Flight>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Gravity { get; set; }

        public virtual ICollection<Flight> FlightArrBody { get; set; }
        public virtual ICollection<Flight> FlightDepBody { get; set; }
    }
}
