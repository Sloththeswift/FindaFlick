namespace FindaFlick
{
    public class SearchResults
    {
        public int page { get; set; }
        public Movie[] results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}