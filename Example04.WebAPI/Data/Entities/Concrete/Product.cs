using Example04.WebAPI.Data.Entities.Abstract;

namespace Example04.WebAPI.Data.Entities.Concrete
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public short Stock { get; set; }
    }
}
