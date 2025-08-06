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

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAssignmentListDal : EfEntityRepositoryBase<AssignmentList, ToDoAppContext>, IAssignmentListDal
    {
        public List<AssignmentListDetailDto> GetAssignmentListDetails()
        {
            using (var context = new ToDoAppContext())
            {
                return context.AssignmentList
                              .Include(al => al.Assignments)
                              .Select(al => new AssignmentListDetailDto
                              {
                                  Id = al.Id,
                                  Name = al.Name,
                                  UserId = al.UserId,
                                  Assignment = al.Assignments.Select(a => new AssignmentDetailDto
                                  {
                                      Id = a.Id,
                                      AssignmentName = a.AssignmentName,
                                      Message = a.Message,
                                      IsCompleted = a.IsCompleted,
                                      CreationDate = a.CreationDate,
                                      DeadlineDate = a.DeadlineDate
                                  }).ToList()
                              })
                              .ToList();
            }
        }

        public AssignmentListDetailDto GetAssignmentListDetailById(int assignmentListId)
        {
            using (var context = new ToDoAppContext())
            {
                return context.AssignmentList
                              .Include(al => al.Assignments)
                              .Where(al => al.Id == assignmentListId)
                              .Select(al => new AssignmentListDetailDto
                              {
                                  Id = al.Id,
                                  Name = al.Name,
                                  UserId = al.UserId,
                                  Assignment = al.Assignments.Select(a => new AssignmentDetailDto
                                  {
                                      Id = a.Id,
                                      AssignmentName = a.AssignmentName,
                                      Message = a.Message,
                                      IsCompleted = a.IsCompleted,
                                      CreationDate = a.CreationDate,
                                      DeadlineDate = a.DeadlineDate
                                  }).ToList()
                              })
                              .SingleOrDefault();
            }
        }

        
    }
}
