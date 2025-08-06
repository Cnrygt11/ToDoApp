using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class UserWithAssignmentListsDto : IDto
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public List<AssignmentList> AssignmentLists { get; set; }
    }
}
