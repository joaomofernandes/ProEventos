namespace CarShowroom.Domain
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string ModelName { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string FuelType { get; set; }
        public string EngineType { get; set; }

    }
}
