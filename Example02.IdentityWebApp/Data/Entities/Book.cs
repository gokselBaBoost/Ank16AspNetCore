namespace Example02.IdentityWebApp.Data.Entities
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public DateOnly PublisherDate { get; set; }
    }
}
