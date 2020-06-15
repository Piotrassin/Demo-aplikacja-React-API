using System;
using System.Collections.Generic;

namespace IPB_Końcowy.Models
{
    public partial class Labresults
    {
        public int Id { get; set; }
        public int? Description { get; set; }
        public int UserPersonId { get; set; }

        public virtual User UserPerson { get; set; }
    }
}
