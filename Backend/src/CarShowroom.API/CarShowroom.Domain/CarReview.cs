using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Domain
{
    public class CarReview
    {
        public int Id { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public int CarModelId { get; set; } // Reference to associated CarModel
        public int UserId { get; set; } // Reference to associated User
                                        // Add other properties as needed
    }
}
