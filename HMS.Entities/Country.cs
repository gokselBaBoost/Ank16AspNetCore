namespace HMS.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public virtual IEnumerable<City> Cities { get; set;}
    }
}
