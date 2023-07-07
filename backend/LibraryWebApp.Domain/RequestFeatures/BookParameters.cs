namespace LibraryWebApp.Domain.RequestFeatures
{
    public class BookParameters : RequestParameters
    {
        public decimal MinRating { get; set; }
        public decimal MaxRating { get; set; }
        public bool ValidRatingRange => MaxRating > MinRating;
        public string? SearchTerm { get; set; }
    }
}
