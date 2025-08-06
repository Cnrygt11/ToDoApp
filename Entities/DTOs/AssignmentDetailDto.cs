using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class AssignmentDetailDto:IDto
    {
        public Guid Id { get; set; }
        public string AssignmentName { get; set; }
        public string Message { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeadlineDate { get; set; }

    }
}
