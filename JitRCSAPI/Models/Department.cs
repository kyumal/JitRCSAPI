using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JitRCSAPI.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string DepartmentCode { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string DepartmentName { get; set; }
    }
}
