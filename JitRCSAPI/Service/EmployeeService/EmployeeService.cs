using JitRCSAPI.Data;
using JitRCSAPI.Dtos.DepartmentDto;
using JitRCSAPI.Dtos;
using JitRCSAPI.Models;
using JitRCSAPI.Utilities.CustomExceptions;
using JitRCSAPI.Dtos.EmployeeDto;
using Microsoft.EntityFrameworkCore;

namespace JitRCSAPI.Service.EmployeeService
{
    public class EmployeeService: IEmployeeService
    {
        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmployeeService(DataContext dataContext, IHttpContextAccessor httpContextAccessor)
        {
            _dataContext = dataContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<List<GetEmployeeDto>?>> Add(AddEmployeeDto creating)
        {
            var serviceRes = new ServiceResponse<List<GetEmployeeDto>?>();

            var newRecord = new Employee()
            {
                FirstName = creating.FirstName,
                LastName = creating.LastName,
                EmailAddress = creating.EmailAddress,
                DateOfBirth = creating.DateOfBirth,
                Salary = creating.Salary,
                DepartmentId = creating.DepartmentId,

            };
            _dataContext.Employees.Add(newRecord);
            await _dataContext.SaveChangesAsync();

            var all = await _dataContext.Employees.ToListAsync();
            serviceRes.Data = all.Select(all => (GetEmployeeDto)all).ToList();

            return serviceRes;

        }

        public async Task<ServiceResponse<List<GetEmployeeDto>?>> Delete(int Id)
        {
            var serviceRes = new ServiceResponse<List<GetEmployeeDto>?>();

            var deleting = await _dataContext.Employees.FindAsync(Id);
            if (deleting == null)
            {
                throw new CustomResourceNotFoundException($"Employees with id {Id} not found!");
            }

            _dataContext.Employees.Remove(deleting);

            await _dataContext.SaveChangesAsync();


            var all = await _dataContext.Employees.ToListAsync();
            serviceRes.Data = all.Select(all => (GetEmployeeDto)all).ToList();

            return serviceRes;
        }

        public async Task<ServiceResponse<GetEmployeeDto?>> Get(int Id)
        {
            var serviceRes = new ServiceResponse<GetEmployeeDto?>();

            var selected = await _dataContext.Employees.Where(s => s.Id == Id).FirstOrDefaultAsync();

            if (selected == null)
            {
                throw new CustomResourceNotFoundException($"Employees with id {Id} not found!");
            }

            serviceRes.Data = (GetEmployeeDto)selected!;

            return serviceRes;
        }

        public async Task<ServiceResponse<List<GetEmployeeDto>?>> GetAll()
        {
            var serviceRes = new ServiceResponse<List<GetEmployeeDto>?>();

            var all = await _dataContext.Employees.ToListAsync();
            serviceRes.Data = all.Select(all => (GetEmployeeDto)all).ToList();

            return serviceRes;
        }

        public async Task<ServiceResponse<List<GetEmployeeDto>?>> Update(int Id, AddEmployeeDto updating)
        {
            var serviceRes = new ServiceResponse<List<GetEmployeeDto>?>();

            var existing = await _dataContext.Employees.FindAsync(Id);
            if (existing == null)
            {
                throw new CustomResourceNotFoundException($"Employees with id {Id} not found!");
            }

            existing.FirstName = updating.FirstName;
            existing.LastName = updating.LastName;
            existing.EmailAddress = updating.EmailAddress;
            existing.DateOfBirth = updating.DateOfBirth;
            existing.Salary = updating.Salary;
            existing.DepartmentId = updating.DepartmentId;

            await _dataContext.SaveChangesAsync();

            var all = await _dataContext.Employees.ToListAsync();
            serviceRes.Data = all.Select(all => (GetEmployeeDto)all).ToList();


            return serviceRes;
        }
    }
}
