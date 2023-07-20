using AutoMapper;
using LibraryWebApp.Domain.Entities.Models;
using LibraryWebApp.Domain.Interfaces.Repository;
using LibraryWebApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace LibraryWebApp.Application.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthorService> _authorService;
        private readonly Lazy<IBookService> _bookService;
        private readonly Lazy<IReviewService> _reviewService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<User> userManager, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _authorService = new Lazy<IAuthorService>(() => new
                AuthorService(repositoryManager, logger, mapper));
            _bookService = new Lazy<IBookService>(() => new
                BookService(repositoryManager, logger, mapper));
            _reviewService = new Lazy<IReviewService>(() => new
                ReviewService(repositoryManager, logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new
                AuthenticationService(logger, mapper, userManager, configuration));
        }

        public IAuthorService AuthorService => _authorService.Value;
        public IBookService BookService => _bookService.Value;
        public IReviewService ReviewService => _reviewService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}