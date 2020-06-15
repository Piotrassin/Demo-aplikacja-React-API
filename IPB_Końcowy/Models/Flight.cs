using System;
using System.Collections.Generic;

namespace IPB_Końcowy.Models
{
    public partial class Flight
    {
        public Flight()
        {
            Personalizedoffer = new HashSet<Personalizedoffer>();
            Ticket = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public DateTimeOffset DepDate { get; set; }
        public DateTimeOffset ArrDate { get; set; }
        public string Description { get; set; }
        public int DepBodyId { get; set; }
        public int ArrBodyId { get; set; }

        public virtual Celestialbody ArrBody { get; set; }
        public virtual Celestialbody DepBody { get; set; }
        public virtual ICollection<Personalizedoffer> Personalizedoffer { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
