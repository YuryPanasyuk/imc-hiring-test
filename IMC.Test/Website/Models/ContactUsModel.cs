using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class ContactUsModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string UnitApt { get; set; }
        public string City { get; set; }
        public string ProvinceTerritory { get; set; }
        public string Email { get; set; }
    }

    public class CitiesModel
    {
        public List<string> Cities { get; set; }
    }
}