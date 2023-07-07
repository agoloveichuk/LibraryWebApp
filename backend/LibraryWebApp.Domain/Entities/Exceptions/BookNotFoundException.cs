using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApp.Domain.Entities.Exceptions
{
    public class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException(Guid bookId)
            : base($"Book with id: {bookId} doesn't exist in the database.")

        {
        }
    }
}
