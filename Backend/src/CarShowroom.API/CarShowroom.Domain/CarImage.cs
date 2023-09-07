using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Domain
{
    public class CarImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Caption { get; set; }
        public int CarListingId { get; set; } // Reference to associated CarListing
                                              
    }
}
