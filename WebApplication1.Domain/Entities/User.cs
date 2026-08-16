using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Domain.Enums;

namespace WebApplication1.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        [MinLength(4, ErrorMessage = "First Name must be at least 4 characters.")]
        [MaxLength(12, ErrorMessage = "First Name cannot exceed 12 characters.")]
        public string FirstName { get; set; }

        [MinLength(4, ErrorMessage = "Last Name must be at least 4 characters.")]
        [MaxLength(12, ErrorMessage = "Last Name cannot exceed 12 characters.")]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality {  get; set; }
        public string Email { get; set; }

        [MinLength(4, ErrorMessage = "User Name must be at least 4 characters.")]
        [MaxLength(12, ErrorMessage = "User Name cannot exceed 12 characters.")]
        public string UserName { get; set; }

        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        [MaxLength(12, ErrorMessage = "Password cannot exceed 12 characters.")]
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string NationalNumber { get; set; }


        [ForeignKey("EmployeeId")]
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
