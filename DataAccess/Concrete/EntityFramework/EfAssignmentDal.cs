using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAssignmentDal : EfEntityRepositoryBase<Assignment, ToDoAppContext>, IAssignmentDal
    {
        public List<AssignmentDetailDto> GetAssignmentDetails()
        {
            using (ToDoAppContext context = new ToDoAppContext())
            {
                var result = from a in context.Assignment
                             join al in context.AssignmentList
                             on a.AssignmentListId equals al.Id
                             select new AssignmentDetailDto
                             {
                                 Id = a.Id,
                                 AssignmentName = a.AssignmentName,
                                 Message = a.Message,
                                 IsCompleted = a.IsCompleted,
                                 CreationDate = a.CreationDate,
                                 DeadlineDate = a.DeadlineDate,
                             };
                return result.ToList();
            }
        
        }      
    }
}


