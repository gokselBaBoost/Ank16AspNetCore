namespace Example02.IdentityWebApp.Data.Entities
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        DateTime Created { get; set; }
        DateTime? Updated { get; set; }
    }
}
