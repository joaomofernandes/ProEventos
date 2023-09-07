namespace CarShowroom.Domain
{
    public class CarSpecification
    {
        public int Id { get; set; }
        public int CarModelId { get; set; } // Reference to associated CarModel
        public string EngineSpecifications { get; set; }
        public string Dimensions { get; set; }
        public string SafetyFeatures { get; set; }
    }
}