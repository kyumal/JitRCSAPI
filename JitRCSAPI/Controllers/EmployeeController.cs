using JitRCSAPI.Dtos.DepartmentDto;
using JitRCSAPI.Dtos;
using JitRCSAPI.Service.DepartmentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JitRCSAPI.Service.EmployeeService;
using JitRCSAPI.Dtos.EmployeeDto;

namespace JitRCSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {

            _employeeService = employeeService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetEmployeeDto>>>> GetAll()
        {
            var result = await _employeeService.GetAll();
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("Get/{Id}")]
        public async Task<ActionResult<GetEmployeeDto>> Get(int Id)
        {
            var response = await _employeeService.Get(Id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetEmployeeDto>>> Add(AddEmployeeDto creating)
        {

            var result = await _employeeService.Add(creating);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPut("Update/{Id}")]
        public async Task<ActionResult<ServiceResponse<List<GetEmployeeDto>>>> Update(int Id, AddEmployeeDto updating)
        {

            var response = await _employeeService.Update(Id, updating);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpDelete("Delete/{Id}")]
        public async Task<ActionResult<ServiceResponse<List<GetEmployeeDto>>>> Delete(int Id)
        {
            var response = await _employeeService.Delete(Id);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
