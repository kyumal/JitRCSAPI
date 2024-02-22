using JitRCSAPI.Dtos;
using JitRCSAPI.Dtos.DepartmentDto;
using JitRCSAPI.Models;
using JitRCSAPI.Service.DepartmentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace JitRCSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
          
            _departmentService = departmentService;
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetDepartmentDto>>>> GetAll()
        {
            var result = await _departmentService.GetAll();
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("Get/{Id}")]
        public async Task<ActionResult<GetDepartmentDto>> Get(int Id)
        {
            var response = await _departmentService.Get(Id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("Add")]
        public async Task<ActionResult<ServiceResponse<GetDepartmentDto>>> Add(AddDepartmentDto creating)
        {

            var result = await _departmentService.Add(creating);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPut("Update/{Id}")]
        public async Task<ActionResult<ServiceResponse<List<GetDepartmentDto>>>> Update(int Id, AddDepartmentDto updating)
        {

            var response = await _departmentService.Update(Id, updating);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpDelete("Delete/{Id}")]
        public async Task<ActionResult<ServiceResponse<List<GetDepartmentDto>>>> Delete(int Id)
        {
            var response = await _departmentService.Delete(Id);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

    }
}
