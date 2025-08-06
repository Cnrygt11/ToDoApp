using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAssignmentService
    {
        IDataResult<List<Assignment>> GetAll(string token);
        IDataResult<List<Assignment>> GetByDeadline(DateTime finish, string token);
        IDataResult<List<AssignmentDetailDto>> GetAssignmentDetails(string token);
        IResult IsComplete(Guid id, string token);
        IDataResult<Assignment> GetById(Guid id, string token);
        IResult Add(Assignment assignment, string token);
        IResult Update(Assignment assignment, string token);
        IResult Delete(Assignment assignment, string token);
    }
}
