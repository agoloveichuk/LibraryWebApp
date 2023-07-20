namespace LibraryWebApp.Domain.Interfaces.Repository
{
    public interface IRepositoryManager
    {
        IAuthorRepository Author { get; }
        IBookRepository Book { get; }
        IReviewRepository Review { get; }
        Task SaveAsync();
    }
}
