using System.ComponentModel.DataAnnotations;

namespace JitRCSAPI.Dtos.DepartmentDto
{
    public class AddDepartmentDto
    {
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
    }
}
