using AutoMapper;
using Contracts;
using Entities.Model;
using InterviewTask.EmployeeManagement.Dtos;
using InterviewTask.EmployeeManagement.Enums;
using InterviewTask.EmployeeManagement.ValidationContainers;
using InterViewTask.DepartmentManagement.Logging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace InterviewTask.EmployeeManagement.Controllers
{

    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;

        private readonly ILoggerManager _logger;

        private readonly IMapper _mapper;

        public EmployeesController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(EmployeeListDto[]), 200)]
        public IActionResult GetEmployeets()
        {
            var Employeets = _repository.Employee.GetAllEmployees(trackChanges: false);

            var EmployeetsDto = _mapper.Map<List<EmployeeListDto>>(Employeets);

            return Ok(EmployeetsDto);
        }

        [HttpGet("details/{id}")]
        [ProducesResponseType(typeof(EmployeeDetailDto), 200)]
        public IActionResult GetEmployeet(Guid id)
        {
            var Employeet = _repository.Employee.GetEmployee(id, trackChanges: false);
            if (Employeet == null)
            {
                _logger.LogInfo($"Employeet with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var EmployeetDto = _mapper.Map<EmployeeDetailDto>(Employeet);
            return Ok(EmployeetDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployeet(Guid id)
        {
            var employee = _repository.Employee.GetEmployee(id, trackChanges: false);
            if (employee == null)
            {
                _logger.LogInfo($"Employeet with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            if (employee.HasDependant())
                return BadRequest("You can't delete this Employeet, please delete its dependencies first!");

            _repository.Employee.DeleteEmployee(employee);

            if (_repository.Save())
                return Ok();

            return BadRequest("Can't delete this Employeet");
        }

        [HttpPost]
        public IActionResult CreateEmployeet(CreateEmployeeDto input)
        {
            var result = ValidateManager(input.DepartmentId);

            if (result.Status == CheckResultEnum.NotFound)
            {
                _logger.LogInfo($"Manager with id: {input.ManagerId} doesn't exist in the database.");
                return NotFound("There is no manager with the Id selected");
            }

            var employee = _mapper.Map<Employee>(input);

            _repository.Employee.AddEmployee(employee);

            if (_repository.Save())
                return Ok();

            return BadRequest("Can't add this Employeet");
        }

        [HttpPut]
        public IActionResult UpdateEmployeet(UpdateEmployeeDto input)
        {
            var result = ValidateManager(input.ManagerId);

            if (result.Status == CheckResultEnum.NotFound)
            {
                _logger.LogInfo($"Manager with id: {input.ManagerId} doesn't exist in the database.");
                return NotFound("There is no manager with the Id selected");
            }

            var employee = _mapper.Map<Employee>(input);

            _repository.Employee.UpdateEmployee(employee);

            if (_repository.Save())
                return Ok();

            return BadRequest("Can't update this Employeet");
        }

        private CheckResult<Employee> ValidateManager(Guid? id)
        {
            if (id == null)
                return new CheckResult<Employee> { Status = CheckResultEnum.Nochecking };

            var manager = _repository.Employee.GetEmployee(id.Value, trackChanges: false);
            if (manager == null)
            {
                _logger.LogInfo($"Manager with id: {id.Value} doesn't exist in the database.");
                return new CheckResult<Employee> { Status = CheckResultEnum.NotFound };
            }

            return new CheckResult<Employee> { Status = CheckResultEnum.Success, Result = manager };
        }
    }
}
