using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
