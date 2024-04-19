namespace Example05.WebApplication.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        public override string ToString()
        {
            return "/" + this.Controller + "/" + this.Action;
        }
    }
}
