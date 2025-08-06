using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AssignmentAddDto
    {
        public string AssignmentName { get; set; }
        public string Message { get; set; }
        public DateTime DeadlineDate { get; set; }
        public int AssignmentListId { get; set; }
    }

}

