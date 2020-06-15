using System;
using System.Collections.Generic;

namespace IPB_Końcowy.Models
{
    public partial class User
    {
        public User()
        {
            Application = new HashSet<Application>();
            Labresults = new HashSet<Labresults>();
            Personalizedoffer = new HashSet<Personalizedoffer>();
            Ticket = new HashSet<Ticket>();
        }

        public int PersonId { get; set; }
        public decimal PaidSoFar { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime? Birthdate { get; set; }
        public string SpacesuitSize { get; set; }
        public byte? PaymentByInstallments { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<Application> Application { get; set; }
        public virtual ICollection<Labresults> Labresults { get; set; }
        public virtual ICollection<Personalizedoffer> Personalizedoffer { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
