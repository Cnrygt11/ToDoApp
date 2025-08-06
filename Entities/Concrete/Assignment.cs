using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
   public class Assignment : IEntity
    {
        public Guid Id { get; set; }
        public string AssignmentName { get; set; }
        public string Message { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeadlineDate { get; set; }
        public int AssignmentListId { get; set; }
        public AssignmentList AssignmentList { get; set; }

    }
}
