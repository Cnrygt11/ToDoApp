using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        IAssignmentService _assignmentService;
        IAssignmentListService _assignmentListService;
        public AssignmentsController(IAssignmentService assignmentService, IAssignmentListService assignmentListService)
        {
            _assignmentService = assignmentService;
            _assignmentListService = assignmentListService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var result = _assignmentService.GetAll(token);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(Guid id)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var result = _assignmentService.GetById(id,token);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] AssignmentAddDto dto)
        {
            string token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            var assignment = new Assignment
            {
                AssignmentName = dto.AssignmentName,
                Message = dto.Message,
                DeadlineDate = dto.DeadlineDate,
                AssignmentListId = dto.AssignmentListId
            };

            var result = _assignmentService.Add(assignment, token);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }


        [HttpPut("iscomplete")]
        public IActionResult IsComplete(Guid id)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var result = _assignmentService.IsComplete(id,token);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbylistid")]
        public IActionResult GetAllByAssignmentListId(int id)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var result = _assignmentListService.GetAllByAssignmentListId(id, token);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
