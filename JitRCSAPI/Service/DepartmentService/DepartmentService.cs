using JitRCSAPI.Dtos.DepartmentDto;
using JitRCSAPI.Dtos;
using JitRCSAPI.Models;
using JitRCSAPI.Data;
using Microsoft.EntityFrameworkCore;
using JitRCSAPI.Utilities.CustomExceptions;

namespace JitRCSAPI.Service.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DepartmentService(DataContext dataContext, IHttpContextAccessor httpContextAccessor)
        {
            _dataContext = dataContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<List<GetDepartmentDto>?>> Add(AddDepartmentDto creating)
        {
            var serviceRes = new ServiceResponse<List<GetDepartmentDto>?>();
       
                var newRecord = new Department()
                {
                    DepartmentCode = creating.DepartmentCode,
                    DepartmentName = creating.DepartmentName,
                 
                };
                _dataContext.Departments.Add(newRecord);
                await _dataContext.SaveChangesAsync();

                var all = await _dataContext.Departments.ToListAsync();
                serviceRes.Data = all.Select(all => (GetDepartmentDto)all).ToList();


                return serviceRes;
            
          
        }

        public async Task<ServiceResponse<List<GetDepartmentDto>?>> Delete(int Id)
        {
            var serviceRes = new ServiceResponse<List<GetDepartmentDto>?>();

            var deleting = await _dataContext.Departments.FindAsync(Id);
            if (deleting == null)
            {
                throw new CustomResourceNotFoundException($"Car with id {Id} not found!");
            }

            _dataContext.Departments.Remove(deleting);

            await _dataContext.SaveChangesAsync();


            var all = await _dataContext.Departments.ToListAsync();
            serviceRes.Data = all.Select(all => (GetDepartmentDto)all).ToList();

            return serviceRes;
        }

        public async Task<ServiceResponse<GetDepartmentDto?>> Get(int Id)
        {
            var serviceRes = new ServiceResponse<GetDepartmentDto?>();

            var selected = await _dataContext.Departments.Where(s => s.Id == Id).FirstOrDefaultAsync();

            if (selected == null)
            {
                throw new CustomResourceNotFoundException($"Car with id {Id} not found!");
            }

            serviceRes.Data = (GetDepartmentDto)selected!;

            return serviceRes;
        }

        public async Task<ServiceResponse<List<GetDepartmentDto>?>> GetAll()
        {
            var serviceRes = new ServiceResponse<List<GetDepartmentDto>?>();

            var all = await _dataContext.Departments.ToListAsync();
            serviceRes.Data = all.Select(all => (GetDepartmentDto)all).ToList();

            return serviceRes;
        }

        public async Task<ServiceResponse<List<GetDepartmentDto>?>> Update(int Id, AddDepartmentDto updating)
        {
            var serviceRes = new ServiceResponse<List<GetDepartmentDto>?>();

            var existing = await _dataContext.Departments.FindAsync(Id);
            if (existing == null)
            {
                throw new CustomResourceNotFoundException($"Car with id {Id} not found!");
            }

            existing.DepartmentCode = updating.DepartmentCode;
            existing.DepartmentName = updating.DepartmentName;
            

            await _dataContext.SaveChangesAsync();


            var all = await _dataContext.Departments.ToListAsync();
            serviceRes.Data = all.Select(all => (GetDepartmentDto)all).ToList();


            return serviceRes;
        }
    }
}
