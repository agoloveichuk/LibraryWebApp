namespace LibraryWebApp.Domain.Interfaces.Services
{
    public interface IServiceManager
    {
        IAuthorService AuthorService { get; }
        IBookService BookService { get; }
        IReviewService ReviewService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
