using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3Group1
{
    public class Planets
    {
        public string Name { get; set; }
        public string Color { get; set; }
        [Key]
        public int PlanetID { get; set; }

        public void SetPlanetID()
        {
            PlanetID += 1;
        }
    }
}
