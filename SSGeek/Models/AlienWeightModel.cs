using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSGeek.Models
{
    public class AlienWeightModel
    {

        public int EarthMass { get; set; }
        public string Name { get; set; }
        public double WeightMod { get; }
        public double EarthDistance { get; set; }
        public Dictionary<string, double> WeightMods
        {
            get
            {
                var dictionary = new Dictionary<string, double>();


                dictionary["Mercury"] = 0.38;
                dictionary["Venus"] = 0.91;
                dictionary["Earth"] = 1;
                dictionary["Mars"] = .38;
                dictionary["Jupiter"] = 2.34;
                dictionary["Saturn"] = 1.06;
                dictionary["Uranus"] = .92;
                dictionary["Neptune"] = 1.19;
                dictionary["Pluto"] = 0.06;

                return dictionary;
            }
        }

        //public AlienWeightModel()
        //{
        //    this.WeightMod = WeightMods[Name];
        //}


        public double GetAlienWeight()
        {
            return EarthMass * WeightMods[this.Name];
        }
    }


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





