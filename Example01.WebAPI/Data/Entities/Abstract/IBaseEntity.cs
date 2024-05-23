namespace Example01.WebAPI.Data.Entities.Abstract
{
    public interface IBaseEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}