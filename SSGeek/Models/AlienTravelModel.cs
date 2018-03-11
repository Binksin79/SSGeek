using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSGeek.Models
{
    public class AlienTravelModel
    {

        public int Age { get; set; }
        public string Name { get; set; }
        public string TransportMode { get; set; }
        public Dictionary<string, double> TransportModes
        {
            get
            {
                var dictionary = new Dictionary<string, double>();

                dictionary["Walking"] = 3;
                dictionary["Car"] = 100;
                dictionary["Bullet Train"] = 200;
                dictionary["Boeing 747"] = 570;
                dictionary["Concorde"] = 1350;

                return dictionary;
            }
        }
        
        public Dictionary<string, double> DistanceFromEarth
        {
            get
            {
                var dictionary = new Dictionary<string, double>();


                dictionary["Mercury"] = 56974146;
                dictionary["Venus"] = 25724767;
                dictionary["Earth"] = 0;
                dictionary["Mars"] = 48678219;
                dictionary["Jupiter"] = 390674710;
                dictionary["Saturn"] = 792240270;
                dictionary["Uranus"] = 1692662530;
                dictionary["Neptune"] = 2703959960;
                dictionary["Pluto"] = 4670000000;

                return dictionary;
            }
        }

        public double GetTime()
        {
            return (DistanceFromEarth[Name] / TransportModes[TransportMode]) / 8760;
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