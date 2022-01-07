using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Automation_Laboratory_Backend.Models;
using Automation_Laboratory_Backend.Repositories;
using Automation_Laboratory_Backend.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Automation_Laboratory_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IDeviceService _deviceService;

        public DeviceController(IDeviceRepository deviceRepository, IDeviceService deviceService)
        {
            _deviceRepository = deviceRepository;
            _deviceService = deviceService;
        }

        // GET: api/<DeviceController>
        // The code below will get all the devices which isActive value is true.
        [HttpGet] // api/device
        public IActionResult Get()
        {
            var everyDevice = _deviceRepository.Read();
            return new JsonResult(everyDevice);
        }

        // The code below will get all the devices which isActive value is false.
        [HttpGet("DeviceActiveFalse")] // api/device/DeviceActiveFalse
        public IActionResult GetIsActiveFalse()
        {
            var everyDeviceFalse = _deviceRepository.ReadIsActiveFalse();
            return new JsonResult(everyDeviceFalse);
        }

        // GET api/<DeviceController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var certainDevice = _deviceRepository.Read(id);
            return new JsonResult(certainDevice);
        }

        // POST api/<DeviceController>
        [HttpPost]
        public IActionResult Post([FromBody] Device device)
        {
            var createDevice = _deviceService.Create(device);
            return new JsonResult(createDevice);
        }

        // PUT api/<DeviceController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Device device)
        {
            var updateDevice = _deviceService.Update(device);
            return new JsonResult(updateDevice);
        }

        // DELETE api/<DeviceController>/5
        // This is will not delete any information.
        // Instead it will change device's IsActive status to false.
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _deviceService.SetStatusFalse(id);
        }

        // This will change device's IsActive status to true.
        [HttpPatch("{id}")]
        public void Patch(int id)
        {
            _deviceService.SetStatusTrue(id);
        }


        // This is will delete all the information about certain device.
        // Once this method has been executed no information can be recovered.
        [HttpDelete("DeviceActiveFalse/{id}")]
        public void DeletePermanently(int id)
        {
            _deviceService.Delete(id);
        }
    }
}