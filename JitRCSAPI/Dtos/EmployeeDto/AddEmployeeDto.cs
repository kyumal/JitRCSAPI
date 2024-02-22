using System.ComponentModel.DataAnnotations;

namespace JitRCSAPI.Dtos.EmployeeDto
{
    public class AddEmployeeDto
    {   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
    }
}
