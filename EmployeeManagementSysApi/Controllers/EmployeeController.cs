using EmployeeManagementSys.DAL.Data.Model;
using EmployeeManagementSys.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagementSysApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmpAdvnService _empDetAdvnService;

        public EmployeeController(IEmpAdvnService empDetAdvnService)
        {
            _empDetAdvnService = empDetAdvnService;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _empDetAdvnService.GetAllEmployee();
            return Ok(result);
            //return new string[] { "value1", "value2" };
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _empDetAdvnService.GetEmpDetailsById(id);
            return Ok(res);
            //return "value";
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async void Post([FromBody] EmployeeAdvn empDetAdvn)
        {
            await _empDetAdvnService.UpdateEmployee(empDetAdvn);
            
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] EmployeeAdvn empDetAdvn)
        {
            await _empDetAdvnService.CreateEmployee(empDetAdvn);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await _empDetAdvnService.DeleteEmployee(id);
        }
    }
}
