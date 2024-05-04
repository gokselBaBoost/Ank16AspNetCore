namespace HMS.WebApp.Models
{
    public class CountryEditListViewModel : CountryAddViewModel
    {
        public int Id { get; set; }

        public int RowNum { get; set; }

        public ICollection<CityEditListViewModel> Cities { get; set; }
    }
}
