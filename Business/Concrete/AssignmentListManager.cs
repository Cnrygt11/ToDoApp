using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Business.Abstract;
using static Entities.DTOs.AssignmentListDetailDto;
using Entities.DTOs;
using Core.Utilities.Security;

namespace Business.Concrete
{
    public class AssignmentListManager : IAssignmentListService
    {
        IAssignmentListDal _assignmentListDal;
        IAssignmentDal _assignmentDal;
        private readonly JwtTokenHelper _tokenHelper;


        public AssignmentListManager(IAssignmentListDal assignmentListDal, IAssignmentDal assignmentDal, JwtTokenHelper tokenHelper)
        {
            _assignmentListDal = assignmentListDal;
            _assignmentDal = assignmentDal;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<List<AssignmentListDetailDto>> GetAll(string token)
        {
            var userId = _tokenHelper.GetUserIdFromToken(token);
            if (userId == null)
            {
                return new ErrorDataResult<List<AssignmentListDetailDto>>(null, Messages.TokenInvalid);
            }

            var dtoList = _assignmentListDal
                .GetAssignmentListDetails()
                .Where(x => x.UserId == userId)
                .ToList();

            if (dtoList == null || dtoList.Count == 0)
            {
                return new ErrorDataResult<List<AssignmentListDetailDto>>(null, Messages.AssignmentListNotFound);
            }

            return new SuccessDataResult<List<AssignmentListDetailDto>>(dtoList, Messages.AssignmentListListed);
        }

        public IDataResult<AssignmentListDetailDto> GetById(int assignmentListId, string token)
        {
            var userId = _tokenHelper.GetUserIdFromToken(token);
            if (userId == null)
            {
                return new ErrorDataResult<AssignmentListDetailDto>(null, Messages.TokenInvalid);
            }

            var result = _assignmentListDal.GetAssignmentListDetailById(assignmentListId);

            if (result == null || result.UserId != userId)
            {
                return new ErrorDataResult<AssignmentListDetailDto>(null, Messages.AssignmentListNotFound);
            }

            return new SuccessDataResult<AssignmentListDetailDto>(result, Messages.AssignmentListListed);
        }



        public IDataResult<List<Assignment>> GetAllByAssignmentListId(int id, string token)
        {
            var userId = _tokenHelper.GetUserIdFromToken(token);
            if (userId == null)
            {
                return new ErrorDataResult<List<Assignment>>(null, Messages.TokenInvalid);
            }

            var list = _assignmentListDal.Get(al => al.Id == id && al.UserId == userId);
            if (list == null)
            {
                return new ErrorDataResult<List<Assignment>>(null, Messages.AssignmentListNotFound);
            }

            var result = _assignmentDal.GetAll(a => a.AssignmentListId == id);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Assignment>>(null, Messages.AssignmentNotFound);
            }

            return new SuccessDataResult<List<Assignment>>(result, Messages.AssignmentListed);
        }


        public IResult Update(AssignmentList list, string token)
        {
            var userId = _tokenHelper.GetUserIdFromToken(token);
            if (userId == null)
            {
                return new ErrorResult(Messages.TokenInvalid);
            }

            var result = _assignmentListDal.Get(al => al.Id == list.Id && al.UserId == userId);
            if (result == null)
            {
                return new ErrorResult(Messages.AssignmentListNotFound);
            }

            result.Name = list.Name;
            _assignmentListDal.Update(result);
            return new SuccessResult(Messages.AssignmentListUpdated);
        }


        public IResult Delete(int id, string token)
        {
            var userId = _tokenHelper.GetUserIdFromToken(token);
            if (userId == null)
            {
                return new ErrorResult(Messages.TokenInvalid);
            }

            var result = _assignmentListDal.Get(al => al.Id == id && al.UserId == userId);
            if (result == null)
            {
                return new ErrorResult(Messages.AssignmentListNotFound);
            }

            _assignmentListDal.Delete(result);
            return new SuccessResult(Messages.AssignmentListDeleted);
        }



        [ValidationAspect(typeof(AssingmentListValidator))]
        public IResult Add(AssignmentList assignmentList, string token)
        {
            var userId = _tokenHelper.GetUserIdFromToken(token);

            if (userId == null)
            {
                return new ErrorResult(Messages.TokenInvalid);
            }

            IResult result = BusinessRules.Run(CheckIfAssignmentListNameExists(assignmentList));

            if (result != null)
            {
                return result;
            }

            assignmentList.UserId = userId.Value;
            _assignmentListDal.Add(assignmentList);
            return new SuccessResult(Messages.AssignmentListAdded);
        }

        private IResult CheckIfAssignmentListNameExists(AssignmentList assignmentList)
        {
            var result = _assignmentListDal
                .GetAll(al => al.Name.ToLower() == assignmentList.Name.ToLower() && al.UserId == assignmentList.UserId)
                .Any();

            if (result)
            {
                return new ErrorResult(Messages.AssignmentListNameAlreadyExists);
            }
            return new SuccessResult();
        }


        private int GetNextId()
        {
            var lastAssignmentList = _assignmentListDal.GetAll().OrderByDescending(x => x.Id).FirstOrDefault();
            return lastAssignmentList != null ? lastAssignmentList.Id + 1 : 1;
        }

        private IResult CheckToken(string token)
        {
            var userId = _tokenHelper.GetUserIdFromToken(token);

            if (userId == null)
            {
                return new ErrorResult(Messages.TokenInvalid);
            }
            return new SuccessResult();
        }

        

    }
}
