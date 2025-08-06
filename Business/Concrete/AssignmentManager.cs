using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class AssignmentManager : IAssignmentService
    {
        IAssignmentDal _assignmentDal;
        IAssignmentListDal _assignmentListDal;
        private readonly JwtTokenHelper _tokenHelper;

        public AssignmentManager(IAssignmentListDal assignmentListDal, IAssignmentDal assignmentDal, JwtTokenHelper tokenHelper)
        {
            _assignmentListDal = assignmentListDal;
            _assignmentDal = assignmentDal;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<List<Assignment>> GetAll(string token)
        {
            var userId = _tokenHelper.GetUserIdFromToken(token);

            if (userId == null)
            {
                return new ErrorDataResult<List<Assignment>>(null, Messages.TokenInvalid);
            }

            var result = _assignmentDal.GetAll(a => a.AssignmentList.UserId == userId);

            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Assignment>>(null, Messages.AssignmentNotFound);
            }

            return new SuccessDataResult<List<Assignment>>(result, Messages.AssignmentListed);
        }

       

        public IDataResult<List<AssignmentDetailDto>> GetAssignmentDetails(string token)
        {
            var userId = _tokenHelper.GetUserIdFromToken(token);

            if (userId == null)
            {
                return new ErrorDataResult<List<AssignmentDetailDto>>(null, Messages.TokenInvalid);
            }

            var result = _assignmentDal.GetAssignmentDetails();
            if (result.Count == 0)
                return new ErrorDataResult<List<AssignmentDetailDto>>(null, Messages.AssignmentNotFound);

            return new SuccessDataResult<List<AssignmentDetailDto>>(result, Messages.AssignmentListed);

        }

        public IDataResult<List<Assignment>> GetByDeadline(DateTime finish, string token)
        {
            var userId = _tokenHelper.GetUserIdFromToken(token);

            if (userId == null)
            {
                return new ErrorDataResult<List<Assignment>>(null, Messages.TokenInvalid);
            }

            return new SuccessDataResult<List<Assignment>>(_assignmentDal.GetAll(a => a.DeadlineDate <= finish),Messages.AssignmentListed);
        }

        public IResult IsComplete(Guid id, string token)
        {
            var userId = _tokenHelper.GetUserIdFromToken(token);

            if (userId == null)
            {
                return new ErrorDataResult<List<Assignment>>(null, Messages.TokenInvalid);
            }

            var assignment = _assignmentDal.Get(a => a.Id == id);
            if (assignment != null)
            {
                assignment.IsCompleted = !assignment.IsCompleted;
                _assignmentDal.Update(assignment);
                return new SuccessResult(Messages.AssignmentUpdated);
            }
            return new ErrorResult(Messages.AssignmentNotFound);
        }

        [ValidationAspect(typeof(AssignmentValidator))]
        public IResult Add(Assignment assignment, string token)
        {
            var userId = _tokenHelper.GetUserIdFromToken(token);

            if (userId == null)
            {
                return new ErrorResult(Messages.TokenInvalid);
            }

            var assignmentList = _assignmentListDal.Get(al => al.Id == assignment.AssignmentListId);
            if (assignmentList == null || assignmentList.UserId != userId)
            {
                return new ErrorResult(Messages.AssignmentListNotFound);
            }

            IResult result = BusinessRules.Run(
                CheckIfAssignmentNameExists(assignment),
                CheckIfAssignmentCountOfAssignmentListExceeded(assignment)
            );

            if (result != null)
            {
                return result;
            }

            assignment.Id = Guid.NewGuid();
            assignment.CreationDate = DateTime.UtcNow;
            assignment.IsCompleted = false;

            _assignmentDal.Add(assignment);

            return new SuccessResult(Messages.AssignmentAdded);
        }


        public IDataResult<Assignment> GetById(Guid id, string token)
        {
            var userId = _tokenHelper.GetUserIdFromToken(token);

            if (userId == null)
            {
                return new ErrorDataResult<Assignment>(null, Messages.TokenInvalid);
            }

            var result = _assignmentDal.Get(a => a.Id == id);
            if (result == null)
                return new ErrorDataResult<Assignment>(null, Messages.AssignmentNotFound);
            return new SuccessDataResult<Assignment>(result, Messages.AssignmentListed);
        }

        public IResult Delete(Assignment assignment, string token)
        {
            var userId = _tokenHelper.GetUserIdFromToken(token);

            if (userId == null)
            {
                return new ErrorResult(Messages.TokenInvalid);
            }

            var assignmentToDelete = _assignmentDal.Get(a => a.Id == assignment.Id);
            if (assignmentToDelete == null)
            {
                return new ErrorResult(Messages.AssignmentNotFound);
            }

            _assignmentDal.Delete(assignmentToDelete);
            return new SuccessResult(Messages.AssignmentDeleted);
        }

        [ValidationAspect(typeof(AssignmentUpdateValidator))]
        public IResult Update(Assignment assignment, string token)
        {
            var userId = _tokenHelper.GetUserIdFromToken(token);

            if (userId == null)
            {
                return new ErrorResult(Messages.TokenInvalid);
            }

            var existing = _assignmentDal.Get(a => a.Id == assignment.Id);
            if (existing == null)
            {
                return new ErrorResult(Messages.AssignmentNotFound);
            }

            existing.AssignmentName = assignment.AssignmentName;
            existing.Message = assignment.Message;
            existing.DeadlineDate = assignment.DeadlineDate;
            existing.AssignmentListId = assignment.AssignmentListId;

            _assignmentDal.Update(existing);
            return new SuccessResult(Messages.AssignmentUpdated);
        }

        private IResult CheckIfAssignmentCountOfAssignmentListExceeded(Assignment assignment)
        {
            var result = _assignmentDal.GetAll(a => a.AssignmentListId == assignment.AssignmentListId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.AssignmentLimitExceeded);
            }
            return new SuccessResult();
        }

        private IResult CheckIfAssignmentNameExists(Assignment assignment)
        {
            var result = _assignmentDal
                .GetAll(a => a.AssignmentListId == assignment.AssignmentListId && a.AssignmentName == assignment.AssignmentName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.AssignmentNameAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
