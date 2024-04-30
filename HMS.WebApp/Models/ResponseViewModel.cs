namespace HMS.WebApp.Models
{
    public class ResponseViewModel
    {
        public bool IsSuccess { get; set; }
        public string Error { get; set; }
        public object? Record { get; set; }
    }
}
