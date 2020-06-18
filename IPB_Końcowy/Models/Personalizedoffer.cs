using System;
using System.Collections.Generic;

namespace IPB_Końcowy.Models
{
    public partial class Personalizedoffer
    {
        public int Id { get; set; }
        public int? UserPersonId { get; set; }
        public decimal? Price { get; set; }
        public int Accepted { get; set; }

        public virtual User UserPerson { get; set; }
    }
}
