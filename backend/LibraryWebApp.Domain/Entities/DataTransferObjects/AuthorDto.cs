using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApp.Domain.Entities.DataTransferObjects
{
    public record AuthorDto(Guid Id, string Name, DateTime DateOfBirth);
}
