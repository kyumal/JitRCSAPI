
using JitRCSAPI.Dtos;
using JitRCSAPI.Dtos.DepartmentDto;

namespace JitRCSAPI.Service.DepartmentService
{
    public interface IDepartmentService
    {
        Task<ServiceResponse<List<GetDepartmentDto>?>> GetAll();

        Task<ServiceResponse<GetDepartmentDto?>> Get(int Id);

        Task<ServiceResponse<List<GetDepartmentDto>?>> Add(AddDepartmentDto creating);

        Task<ServiceResponse<List<GetDepartmentDto>?>> Update(int Id, AddDepartmentDto updating);

        Task<ServiceResponse<List<GetDepartmentDto>?>> Delete(int Id);
    }
}
