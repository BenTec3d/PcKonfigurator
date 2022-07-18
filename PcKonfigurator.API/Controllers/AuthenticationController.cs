using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PcKonfigurator.API.Entities;
using PcKonfigurator.API.Repositories;
using PcKonfigurator.Shared.DTOs;
using PcKonfigurator.Shared.Models;
using PcKonfigurator.Shared.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PcKonfigurator.API.Controllers
{
    [Route("api/v:{version:apiVersion}/authentication")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPasswordHashService _passwordHashService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthenticationController(IEmployeeRepository employeeRepository, IPasswordHashService passwordHashService, IConfiguration configuration, IMapper mapper)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _passwordHashService = passwordHashService ?? throw new ArgumentNullException(nameof(passwordHashService));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<string>> Authenticate(LoginDto loginDto)
        {
            var employees = await _employeeRepository.GetEmployeesAsync(loginDto.Login);

            if (employees.IsNullOrEmpty())
                return Unauthorized();

            EmployeeEntity? employeeEntity = null;
            foreach (EmployeeEntity employee in employees)
            {
                if (_passwordHashService.VerifyPasswordHash(loginDto.Password, employee.PasswordHash, employee.PasswordSalt))
                {
                    employeeEntity = employee;
                    break;
                }
            }

            if (employeeEntity is null)
                return Unauthorized();

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>()
            {
                new Claim("sub", employeeEntity.Id.ToString()),
                new Claim("given_name", employeeEntity.FirstName.ToString()),
                new Claim("family-name", employeeEntity.LastName.ToString())
            };

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials
                );

            var employeeToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            var employeeToReturn = _mapper.Map<Employee>(employeeEntity);
            employeeToReturn.Jwt = employeeToken;

            return Ok(employeeToReturn);
        }
    }
}
