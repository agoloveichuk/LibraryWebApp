using LibraryWebApp.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApp.Domain.Entities.DataTransferObjects
{
    public record BookDto(Guid Id, string Title, string Cover, string Content, Genre Genre, decimal Rating);
}
