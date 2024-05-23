using Example01.WebAPI.Data.Entities.Abstract;

namespace Example01.WebAPI.Data.Entities.Concrete
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
