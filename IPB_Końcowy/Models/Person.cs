using System;
using System.Collections.Generic;

namespace IPB_Końcowy.Models
{
    public partial class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int CanLogin { get; set; }

        public virtual Consultant Consultant { get; set; }
        public virtual User User { get; set; }
    }
}
