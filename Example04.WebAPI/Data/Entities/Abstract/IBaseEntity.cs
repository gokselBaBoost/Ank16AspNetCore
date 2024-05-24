
namespace Example04.WebAPI.Data.Entities.Abstract
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        DateTime Created { get; set; }
        DateTime? Updated { get; set; }
    }
}