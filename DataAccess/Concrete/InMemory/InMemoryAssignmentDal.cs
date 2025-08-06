using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryAssignmentDal : IAssignmentDal
    {
        List<Assignment> _assignments;
        public InMemoryAssignmentDal()
        {
            _assignments = new List<Assignment>
                {
                    new Assignment
    {
        Id = Guid.NewGuid(),
        AssignmentName = "Shopping",
        Message = "Buy groceries for the week",
        IsCompleted = false,
        CreationDate = DateTime.Now.AddDays(-3),
        DeadlineDate = DateTime.Now.AddDays(2),
        AssignmentListId = 5
    },
    new Assignment
    {
        Id = Guid.NewGuid(),
        AssignmentName = "Homework",
        Message = "Finish math exercises",
        IsCompleted = false,
        CreationDate = DateTime.Now.AddDays(-1),
        DeadlineDate = DateTime.Now.AddDays(3),
        AssignmentListId = 5
    },
    new Assignment
    {
        Id = Guid.NewGuid(),
        AssignmentName = "Workout",
        Message = "Go to the gym",
        IsCompleted = true,
        CreationDate = DateTime.Now.AddDays(-5),
        DeadlineDate = DateTime.Now.AddDays(-1),
        AssignmentListId = 4
    },
    new Assignment
    {
        Id = Guid.NewGuid(),
        AssignmentName = "Project Report",
        Message = "Write the final project report",
        IsCompleted = false,
        CreationDate = DateTime.Now,
        DeadlineDate = DateTime.Now.AddDays(7),
        AssignmentListId = 4
    },
    new Assignment
    {
        Id = Guid.NewGuid(),
        AssignmentName = "Doctor Appointment",
        Message = "Annual checkup at 10AM",
        IsCompleted = true,
        CreationDate = DateTime.Now.AddDays(-10),
        DeadlineDate = DateTime.Now.AddDays(-8),
        AssignmentListId = 3
    },
    new Assignment
    {
        Id = Guid.NewGuid(),
        AssignmentName = "Call Client",
        Message = "Discuss contract terms",
        IsCompleted = false,
        CreationDate = DateTime.Now.AddDays(-2),
        DeadlineDate = DateTime.Now.AddDays(1),
        AssignmentListId = 3
    },
    new Assignment
    {
        Id = Guid.NewGuid(),
        AssignmentName = "Clean Garage",
        Message = "Organize old boxes",
        IsCompleted = false,
        CreationDate = DateTime.Now.AddDays(-6),
        DeadlineDate = DateTime.Now.AddDays(2),
        AssignmentListId = 2
    },
    new Assignment
    {
        Id = Guid.NewGuid(),
        AssignmentName = "Birthday Gift",
        Message = "Buy gift for Sarah",
        IsCompleted = true,
        CreationDate = DateTime.Now.AddDays(-4),
        DeadlineDate = DateTime.Now.AddDays(-2),
        AssignmentListId = 2
    },
    new Assignment
    {
        Id = Guid.NewGuid(),
        AssignmentName = "Presentation",
        Message = "Prepare slides for team meeting",
        IsCompleted = false,
        CreationDate = DateTime.Now.AddDays(-1),
        DeadlineDate = DateTime.Now.AddDays(4),
        AssignmentListId = 1
    },
    new Assignment
    {
        Id = Guid.NewGuid(),
        AssignmentName = "Read Book",
        Message = "Finish 'Atomic Habits'",
        IsCompleted = false,
        CreationDate = DateTime.Now.AddDays(-7),
        DeadlineDate = DateTime.Now.AddDays(3),
        AssignmentListId = 1
    }
                };
        }
        public void Add(Assignment assignment)
        {
            _assignments.Add(assignment);
        }

        public void Delete(Guid id)
        {
            Assignment assignmentToDelete = _assignments.SingleOrDefault(a => a.Id == id);

            _assignments.Remove(assignmentToDelete);
        }

        public List<Assignment> GetAll()
        {
            return _assignments;
        }

        public void Update(Assignment assignment)
        {
            Assignment assignmentToUpdate = _assignments.SingleOrDefault(a => a.Id == assignment.Id);
            assignmentToUpdate.AssignmentName = assignment.AssignmentName;
            assignmentToUpdate.Message = assignment.Message;
            assignmentToUpdate.IsCompleted = assignment.IsCompleted;
            assignmentToUpdate.CreationDate = assignment.CreationDate;
            assignmentToUpdate.DeadlineDate = assignment.DeadlineDate;
            assignmentToUpdate.AssignmentListId = assignment.AssignmentListId;
        }

        public List<Assignment> GetByAssignmentListId(int assignmentListId)
        {
            return _assignments.Where(a => a.AssignmentListId == assignmentListId).ToList();
        }

        public List<Assignment> GetByAssignmentId(Guid Id)
        {
            return _assignments.Where(a => a.Id == Id).ToList();
        }

        public List<T> GetAll<T>(Expression<Func<T, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Assignment Get(Expression<Func<Assignment, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Assignment> GetAll(Expression<Func<Assignment, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Delete(Assignment entity)
        {
            throw new NotImplementedException();
        }

        public List<AssignmentDetailDto> GetAssignmentDetails()
        {
            throw new NotImplementedException();
        }
    }
}
