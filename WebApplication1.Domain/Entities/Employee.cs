using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Domain.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [Column(TypeName = "Decimal(18,2)")]
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public byte Gender { get; set; }

        [MaxLength(100)]
        public string Position { get; set; }
        public bool IsAction { get; set; }

        //Self Reference
        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }
        public ICollection<Employee> Employees { get; set; }

        public User User { get; set; }
    }
}
