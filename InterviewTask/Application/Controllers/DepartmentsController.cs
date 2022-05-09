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
    [Route("api/departments")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;

        private readonly ILoggerManager _logger;

        private readonly IMapper _mapper;

        public DepartmentsController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(DepartmentListDto[]), 200)]
        public IActionResult GetDepartments()
        {
            var departments = _repository.Department.GetAllDepartments(trackChanges: false);

            var departmentsDto = _mapper.Map<List<DepartmentListDto>>(departments);

            return Ok(departmentsDto);
        }

        [HttpGet("details/{id}")]
        [ProducesResponseType(typeof(DepartmentDetailDto), 200)]
        public IActionResult GetDepartment(Guid id)
        {
            var department = _repository.Department.GetDepartment(id, trackChanges: false);
            if (department == null)
            {
                _logger.LogInfo($"Department with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var departmentDto = _mapper.Map<DepartmentDetailDto>(department);
            return Ok(departmentDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(Guid id)
        {
            var department = _repository.Department.GetDepartment(id, trackChanges: false);
            if (department == null)
            {
                _logger.LogInfo($"Department with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            if (department.HasDependant())
                return BadRequest("You can't delete this department, please delete its dependencies first!");

            _repository.Department.DeleteDepartment(department);

            if (_repository.Save())
                return Ok();

            return BadRequest("Can't delete this department");
        }

        [HttpPost]
        public IActionResult CreateDepartment(CreateDepartmentDto input)
        {
            var result = ValidateManager(input.ManagerId);

            if (result.Status == CheckResultEnum.NotFound)
            {
                _logger.LogInfo($"Manager with id: {input.ManagerId.Value} doesn't exist in the database.");
                return NotFound("There is no manager with the Id selected");
            }

            var department = _mapper.Map<Department>(input);
            department.RelateToManager(result.Result);

            _repository.Department.AddDepartment(department);

            if (_repository.Save())
                return Ok();

            return BadRequest("Can't add this department");
        }

        [HttpPut]
        public IActionResult UpdateDepartment(UpdateDepartmentDto input)
        {
            var result = ValidateManager(input.ManagerId);

            if (result.Status == CheckResultEnum.NotFound)
            {
                _logger.LogInfo($"Manager with id: {input.ManagerId.Value} doesn't exist in the database.");
                return NotFound("There is no manager with the Id selected");
            }

            var department = _mapper.Map<Department>(input);
            department.RelateToManager(result.Result);

            _repository.Department.UpdateDepartment(department);

            if (_repository.Save())
                return Ok();

            return BadRequest("Can't update this department");
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
