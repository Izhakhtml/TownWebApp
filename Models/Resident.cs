using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TownWebApp.Models
{
    public class Resident
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string Gender { get; set; }
        public bool IfBornInTown { get; set; }
        public DateTime BirthYear { get; set; }

    }
}