
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application.DepartmentDtos;
using WebApplication1.Domain.Entities;
using WebApplication1.Infrastructure.Data;

namespace app_homework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        private readonly AppDbContext _dbContext;

        public DepartmentController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var result = from department in _dbContext.Departments
                             select new DepartmentDto
                             {
                                 Id = department.Id,
                                 CompanyId = department.CompanyId,
                                 Name = department.Name,
                                 Description = department.Description,
                                 Budget = department.Budget,
                                 CreatedAt = department.CreatedAt
                             };

                return Ok(result);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public IActionResult GetById([FromQuery] SearchDepartmentDto searchDto)
        {
            try
            {
                var result = from department in _dbContext.Departments
                             where (department.Id == searchDto.Id)
                             select new DepartmentDto
                             {
                                 Id = department.Id,
                                 CompanyId = department.CompanyId,
                                 Name = department.Name,
                                 Description = department.Description,
                                 Budget = department.Budget,
                                 CreatedAt = department.CreatedAt
                             };

                return Ok(result);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] SaveDepartmentDto saveDto)
        {
            try
            {
                var department = new Department()
                {
                    CompanyId = saveDto.CompanyId,
                    Name = saveDto.Name,
                    Description = saveDto.Description,
                    Budget = saveDto.Budget,
                    CreatedAt = saveDto.CreatedAt
                };

                _dbContext.Departments.Add(department);
                _dbContext.SaveChanges();

                return Ok();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] DepartmentDto departmentDto)
        {
            try
            {
                var department = _dbContext.Departments.FirstOrDefault(x => x.Id == departmentDto.Id);

                if (department == null)
                {
                    return NotFound("Department Does Not Exist");
                }

                department.CompanyId = departmentDto.CompanyId;
                department.Name = departmentDto.Name;
                department.Description = departmentDto.Description;
                department.Budget = departmentDto.Budget;
                department.CreatedAt = departmentDto.CreatedAt;

                _dbContext.SaveChanges();

                return Ok();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromQuery] SearchDepartmentDto searchDto)
        {
            try
            {
                var department = _dbContext.Departments.FirstOrDefault(x => x.Id == searchDto.Id);

                if (department == null)
                {
                    return NotFound("Department Does Not Exist");
                }

                _dbContext.Departments.Remove(department);
                _dbContext.SaveChanges();

                return Ok();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}