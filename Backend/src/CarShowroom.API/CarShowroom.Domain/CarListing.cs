using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Domain
{
    public class CarListing
    {
        public int Id { get; set; }
        public string ListingId { get; set; }
        public string VIN { get; set; }
        public int Mileage { get; set; }
        public string Condition { get; set; }
        public string Location { get; set; }
        public bool IsAvailable { get; set; }
        public int CarModelId { get; set; }
    }
}
