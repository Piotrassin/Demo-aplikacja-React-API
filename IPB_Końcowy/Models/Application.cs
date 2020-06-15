using System;
using System.Collections.Generic;

namespace IPB_Końcowy.Models
{
    public partial class Application
    {
        public int Id { get; set; }
        public int UserPersonId { get; set; }
        public DateTime DateOfSubmitting { get; set; }

        public virtual User UserPerson { get; set; }
    }
}
