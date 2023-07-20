namespace LibraryWebApp.Domain.Entities.Exceptions
{
    public sealed class MaxRatingRangeBadRequestException : BadRequestException
    {
        public MaxRatingRangeBadRequestException() : base("Max rating can't be less than min rating.")
        {
        }
    }
}
