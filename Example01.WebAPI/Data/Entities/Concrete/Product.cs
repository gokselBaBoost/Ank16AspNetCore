using Example01.WebAPI.Data.Entities.Abstract;

namespace Example01.WebAPI.Data.Entities.Concrete
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal UnitPrice { get; set; }
        public short Stock { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } 
    }
}
