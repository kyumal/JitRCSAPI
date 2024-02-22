using JitRCSAPI.Dtos.DepartmentDto;
using JitRCSAPI.Dtos;
using JitRCSAPI.Dtos.EmployeeDto;

namespace JitRCSAPI.Service.EmployeeService
{
    public interface IEmployeeService
    {
        Task<ServiceResponse<List<GetEmployeeDto>?>> GetAll();

        Task<ServiceResponse<GetEmployeeDto?>> Get(int Id);

        Task<ServiceResponse<List<GetEmployeeDto>?>> Add(AddEmployeeDto creating);

        Task<ServiceResponse<List<GetEmployeeDto>?>> Update(int Id, AddEmployeeDto updating);

        Task<ServiceResponse<List<GetEmployeeDto>?>> Delete(int Id);
    }
}
