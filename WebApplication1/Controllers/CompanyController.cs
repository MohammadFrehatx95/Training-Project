
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application.CompanyDtos;
using WebApplication1.Application.Interfaces;
using WebApplication1.Domain.Entities;


namespace app_homework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _companyService.GetAll();

                return Ok(result);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public IActionResult GetById([FromQuery] SearchCompanyDto searchDto)
        {
            try
            {
                var result = _companyService.GetById(searchDto.Id);

                return Ok(result);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] SaveCompanyDto saveDto)
        {
            try
            {
                var company = new Company()
                {
                    Name = saveDto.Name,
                    Address = saveDto.Address,
                    Email = saveDto.Email,
                    Phone = saveDto.Phone,
                    CreatedAt = saveDto.CreatedAt
                };

                _companyService.Add(company);

                return Ok();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] CompanyDto companyDto)
        {
            try
            {
                var company = _companyService.GetById(companyDto.Id);  


                company.Name = companyDto.Name;
                company.Address = companyDto.Address;
                company.Email = companyDto.Email;
                company.Phone = companyDto.Phone;
                company.CreatedAt = companyDto.CreatedAt;

                _companyService.Update(company);

                return Ok();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromQuery] SearchCompanyDto searchDto)
        {
            try
            {
                var company = _companyService.GetById(searchDto.Id);

                _companyService.Delete(company);

                return Ok();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}