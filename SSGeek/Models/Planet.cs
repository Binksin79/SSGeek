using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSGeek.Models
{
    public class Planet
    {
        public string Name { get; }
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

        public Planet(string name)
        {
            this.Name = name;
            this.WeightMod = WeightMods[name];
        }
    }

   
}