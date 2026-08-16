
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application.EmployeeDtos;
using WebApplication1.Application.Interfaces;
using WebApplication1.Domain.Entities;


namespace app_homework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var employees = _employeeService.GetAll();
                return Ok(employees);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public IActionResult GetById([FromQuery] SearchEmployeeDto searchDto)
        {
            try
            {
                var result = _employeeService.GetById(searchDto.Id);
                return Ok(result);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] SaveEmployeeDto saveDto)
        {
            try
            {
                var employee = new Employee()
                {
                    FirstName = saveDto.FirstName,
                    LastName = saveDto.LastName,
                    DepartmentId = saveDto.DepartmentId,
                    Email = saveDto.Email,
                    Phone = saveDto.Phone,
                    Salary = saveDto.Salary,
                    HireDate = saveDto.HireDate,
                    Gender = saveDto.Gender,
                    Position = saveDto.Position,
                    IsAction = saveDto.IsAction,
                    ManagerId = saveDto.ManagerId
                };

                _employeeService.Add(employee);

                return Ok();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("Update")]
        public IActionResult Update([FromBody] EmployeeDto empDto)
        {
            try
            {

                var emp = _employeeService.GetById(empDto.Id);

                emp.FirstName = empDto.FirstName;
                emp.LastName = empDto.LastName;
                emp.DepartmentId = empDto.DepartmentId;
                emp.Email = empDto.Email;
                emp.Phone = empDto.Phone;
                emp.Salary = empDto.Salary;
                emp.HireDate = empDto.HireDate;
                emp.Gender = empDto.Gender;
                emp.Position = empDto.Position;
                emp.IsAction = empDto.IsAction;
                emp.ManagerId = empDto.ManagerId;
                _employeeService.Update(emp);

                return Ok();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("Delete")]
        public IActionResult Delete([FromQuery] SearchEmployeeDto searchDto)
        {
            try
            {
                var emp = _employeeService.GetById(searchDto.Id);

                _employeeService.Delete(emp);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}


