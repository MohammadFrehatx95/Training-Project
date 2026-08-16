namespace WebApplication1.Application.DepartmentDtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Budget { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}