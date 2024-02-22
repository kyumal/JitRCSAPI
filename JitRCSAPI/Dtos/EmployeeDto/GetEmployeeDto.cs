using JitRCSAPI.Dtos.DepartmentDto;
using JitRCSAPI.Models;

namespace JitRCSAPI.Dtos.EmployeeDto
{
    public class GetEmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }

        public static explicit operator GetEmployeeDto(Employee entity)
        {
            return new GetEmployeeDto
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                EmailAddress = entity.EmailAddress,
                DateOfBirth = entity.DateOfBirth,
                Age = entity.Age,
                Salary = entity.Salary,
                DepartmentId = entity.DepartmentId,
            };
        }
    }
}
