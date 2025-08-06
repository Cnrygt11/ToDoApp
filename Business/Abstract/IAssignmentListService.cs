using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using static Entities.DTOs.AssignmentListDetailDto;

namespace Business.Abstract
{
    public interface IAssignmentListService
    {
        IDataResult<List<AssignmentListDetailDto>> GetAll(string token);
        IDataResult<AssignmentListDetailDto> GetById(int assignmentListId, string token);
        IResult Add(AssignmentList assignmentList, string token);
        IResult Update(AssignmentList list, string token);
        IResult Delete(int id, string token);
        IDataResult<List<Assignment>> GetAllByAssignmentListId(int id, string token);
    }
}
