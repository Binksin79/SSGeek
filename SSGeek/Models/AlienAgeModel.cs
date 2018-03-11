using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSGeek.Models
{
    public class AlienAgeModel
    {
        public string Name { get; set; }
        public int EarthAge { get; set; }
        public Dictionary<string, double> YearMods
        {
            get
            {
                var dictionary = new Dictionary<string, double>();


                dictionary["Mercury"] = 0.241;
                dictionary["Venus"] = 0.6152;
                dictionary["Earth"] = 1;
                dictionary["Mars"] = 1.8809;
                dictionary["Jupiter"] = 11.8618;
                dictionary["Saturn"] = 29.122;
                dictionary["Uranus"] = 84;
                dictionary["Neptune"] = 164.8;
                dictionary["Pluto"] = 248;

                return dictionary;
            }
        }

        public double GetAlienAge()
        {
            return EarthAge * YearMods[Name];
        }


        //public static List<SelectListItem> Planets { get; } = new List<SelectListItem>()
        //{
        //    new SelectListItem() { Text = "Mercury" },
        //    new SelectListItem() { Text = "Venus" },
        //    new SelectListItem() { Text = "Mars" },
        //    new SelectListItem() { Text = "Jupiter" },
        //    new SelectListItem() { Text = "Saturn" },
        //    new SelectListItem() { Text = "Neptune" },
        //    new SelectListItem() { Text = "Uranus" }
        //};

    }
}