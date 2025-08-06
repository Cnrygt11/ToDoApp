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
    public class AssignmentListsController : ControllerBase
    {
        IAssignmentListService _assignmentListService;
        public AssignmentListsController(IAssignmentListService assignmentListService)
        {
            _assignmentListService = assignmentListService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            var result = _assignmentListService.GetAll(token);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }



        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            var result = _assignmentListService.GetById(id, token);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        [HttpPost("add")]
        public IActionResult Add([FromBody] AssignmentListAddDto dto)
        {
            string token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            var assignmentList = new AssignmentList
            {
                Name = dto.Name,
                Assignments = new List<Assignment>()
            };

            var result = _assignmentListService.Add(assignmentList, token);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }



        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            var result = _assignmentListService.Delete(id, token);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
