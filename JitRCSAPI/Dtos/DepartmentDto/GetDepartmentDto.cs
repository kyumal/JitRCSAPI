using JitRCSAPI.Models;

namespace JitRCSAPI.Dtos.DepartmentDto
{
    public class GetDepartmentDto
    {
        public int Id { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }


        public static explicit operator GetDepartmentDto(Department entity)
        {
            return new GetDepartmentDto
            {
                Id = entity.Id,
                DepartmentCode = entity.DepartmentCode,
                DepartmentName = entity.DepartmentName
            };
        }
    }
}
