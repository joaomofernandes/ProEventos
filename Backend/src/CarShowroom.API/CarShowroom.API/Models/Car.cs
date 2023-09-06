namespace ProEventos.API.Models
{
    public class Car
    {
        public int CarId{ get; set; }
        public string Manufacturer { get; set; }
        public string Model{ get; set; }    
        public string Month_Year { get; set; }
        public string Color { get; set;}
        public string Type { get; set;}
        public string Fuel{ get; set;}
        public int Kms { get; set;}
        public string ImageUrl { get; set; }

    }
}
