using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Landmark
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int ID { get; set; }
        public string Description { get; set; }
        public decimal Distance { get; set; }
        public string TimeToDestination { get; set; }

        public Landmark ()
        {

        }
        public Landmark (string name, string address, int iD, string description)
        {
            Name = name;
            Address = address;
            ID = iD;
            Description = description;
        }
        public Landmark (string name, string address, string description, decimal distance, string timeToDestination)
        {
            Name = name;
            Address = address;
            Description = description;
            Distance = distance;
            TimeToDestination = timeToDestination;
        }
    }
}
