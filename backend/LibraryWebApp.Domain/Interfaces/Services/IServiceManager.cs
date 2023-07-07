using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApp.Domain.Interfaces.Services
{
    public interface IServiceManager
    {
        IAuthorService AuthorService { get; }
        IBookService BookService { get; }
        IReviewService ReviewService { get; }
    }
}
