using LibraryWebApp.Domain.Entities.Models;
using LibraryWebApp.Infrastructure.Data.Repository.Extensions.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace LibraryWebApp.Infrastructure.Data.Repository.Extensions
{
    public static class RepositoryEmployeeExtensions
    {
        public static IQueryable<Book> FilterBooks(this IQueryable<Book> books, decimal minRating, decimal maxRating)
            => books.Where(b => (b.Rating >= minRating && b.Rating <= maxRating));

        public static IQueryable<Book> Search(this IQueryable<Book> books, string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return books;

            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return books.Where(b => b.Title.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Book> Sort(this IQueryable<Book> books, string orderByQueryString)
        {
            if (string.IsNullOrEmpty(orderByQueryString))
                return books.OrderBy(b => b.Title);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Book>(orderByQueryString);

            if (string.IsNullOrEmpty(orderQuery))
                return books.OrderBy(b => b.Title);

            return books.OrderBy(orderQuery);
        }
    }
}
