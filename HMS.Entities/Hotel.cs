namespace HMS.Entities
{
    public class Hotel : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Country Country { get; set; }
        public int CountryId { get; set; }
        public virtual City City { get; set; }
        public int CityId { get; set; }
    }
}
