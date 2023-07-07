using LibraryWebApp.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApp.Infrastructure.Data.Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly AppDbContext _dbContext;
        private readonly Lazy<IAuthorRepository> _authorRepository;
        private readonly Lazy<IBookRepository> _bookRepository;
        private readonly Lazy<IReviewRepository> _reviewRepository;
        public RepositoryManager(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _authorRepository = new Lazy<IAuthorRepository>(() => new
                AuthorRepository(dbContext));
            _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(dbContext));
            _reviewRepository = new Lazy<IReviewRepository>(() => new ReviewRepository(dbContext));
        }
        public IAuthorRepository Author => _authorRepository.Value;
        public IBookRepository Book => _bookRepository.Value;
        public IReviewRepository Review => _reviewRepository.Value;
        public async Task SaveAsync() => await _dbContext.SaveChangesAsync();
    }
}
