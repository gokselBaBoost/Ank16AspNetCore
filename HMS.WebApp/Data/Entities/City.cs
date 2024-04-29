namespace HMS.WebApp.Data.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Country Country { get; set; }
        public int CountryId { get; set; }
        public bool IsActive { get; set; }
    }
}
