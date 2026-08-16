namespace WebApplication1.Application.EmployeeDtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public byte Gender { get; set; }
        public string Position { get; set; }
        public bool IsAction { get; set; }
        public int DepartmentId { get; set; }
        public int? ManagerId { get; set; }
    }
}
