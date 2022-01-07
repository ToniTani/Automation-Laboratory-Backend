using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Automation_Laboratory_Backend.Models;
using Automation_Laboratory_Backend.Repositories;
using Automation_Laboratory_Backend.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Automation_Laboratory_Backend.Controllers
{
    [Route("api/workplace")]
    [ApiController]
    public class WorkplaceController : ControllerBase
    {
        private readonly IWorkplaceRepository _workplaceRepository;
        private readonly IWorkplaceService _workplaceService;

        public WorkplaceController(IWorkplaceRepository workplaceRepository, IWorkplaceService workplaceService)
        {
            _workplaceRepository = workplaceRepository;
            _workplaceService = workplaceService;
        }

        // GET: api/<WorkplaceController>
        [HttpGet]
        public IActionResult Get()
        {
            var everyWorkplace = _workplaceRepository.Read();
            return new JsonResult(everyWorkplace);
        }

        // GET api/<WorkplaceController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var certainWorkplace = _workplaceRepository.Read(id);
            return new JsonResult(certainWorkplace);
        }

        // POST api/<WorkplaceController>
        [HttpPost]
        public IActionResult Post([FromBody] Workplace workplace)
        {
            var createWorkplace = _workplaceService.Create(workplace);
            return new JsonResult(createWorkplace);
        }

        // PUT api/<WorkplaceController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Workplace workplace)
        {
            var updateWorkplace = _workplaceService.Update(workplace);
            return new JsonResult(updateWorkplace);
        }

        // DELETE api/<WorkplaceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}