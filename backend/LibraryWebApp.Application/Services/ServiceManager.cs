using AutoMapper;
using LibraryWebApp.Domain.Interfaces.Repository;
using LibraryWebApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApp.Application.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthorService> _authorService;
        private readonly Lazy<IBookService> _bookService;
        private readonly Lazy<IReviewService> _reviewService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _authorService = new Lazy<IAuthorService>(() => new
                AuthorService(repositoryManager, logger, mapper));
            _bookService = new Lazy<IBookService>(() => new
                BookService(repositoryManager, logger, mapper));
            _reviewService = new Lazy<IReviewService>(() => new
                ReviewService(repositoryManager, logger, mapper));
        }
        public IAuthorService AuthorService => _authorService.Value;
        public IBookService BookService => _bookService.Value;
        public IReviewService ReviewService => _reviewService.Value;
    }
}