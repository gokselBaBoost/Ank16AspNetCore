namespace HMS.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public virtual Country Country { get; set; }
        public int CountryId { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
    }
}
