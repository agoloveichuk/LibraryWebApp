using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApp.Domain.Entities.DataTransferObjects
{
    public record ReviewDto(Guid Id, string Message, string Reviewer, decimal Score);
}
