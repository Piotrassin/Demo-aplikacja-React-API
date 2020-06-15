using System;
using System.Collections.Generic;

namespace IPB_Końcowy.Models
{
    public partial class Consultant
    {
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}
