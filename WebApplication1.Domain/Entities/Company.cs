using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Domain.Entities
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Address { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}
