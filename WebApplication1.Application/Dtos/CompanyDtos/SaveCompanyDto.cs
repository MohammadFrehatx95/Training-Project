namespace WebApplication1.Application.CompanyDtos
{
    public class SaveCompanyDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}