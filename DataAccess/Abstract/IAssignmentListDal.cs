using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IAssignmentListDal : IEntityRepository<AssignmentList>
    {
        public List<AssignmentListDetailDto> GetAssignmentListDetails();

        public AssignmentListDetailDto GetAssignmentListDetailById(int assignmentListId);
    }
}
