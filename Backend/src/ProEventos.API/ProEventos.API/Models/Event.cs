namespace ProEventos.API.Models
{
    public class Event
    {
        public int EventId{ get; set; }
        public string Place { get; set; }
        public string Date{ get; set; }    
        public string Theme { get; set; }
        public int PeopleCount { get; set;}
        public string Lot { get; set;}
        public string ImageUrl { get; set; }

    }
}
