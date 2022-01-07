using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Automation_Laboratory_Backend.Models;

namespace Automation_Laboratory_Backend.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly AutomationlaboratorydbContext _automationlaboratorydbContext;

        public DeviceRepository(AutomationlaboratorydbContext automationlaboratorydbContext)
        {
            _automationlaboratorydbContext = automationlaboratorydbContext;
        }
        public Device Create(Device device)
        {
            _automationlaboratorydbContext.Devices.Add(device);
            _automationlaboratorydbContext.SaveChanges();
            return device;
        }

        // The code below will get all the devices which isActive value is true.
        public List<Device> Read()
        {
            var everyDevice = _automationlaboratorydbContext.Devices
                .Where(e => e.IsActive == true)
                .ToList();
            return everyDevice;
        }

        // The code below will get all the devices which isActive value is false.
        public List<Device> ReadIsActiveFalse()
        {
            var everyDeviceFalse = _automationlaboratorydbContext.Devices
                .Where(e => e.IsActive == false)
                .ToList();
            return everyDeviceFalse;
        }

        public Device Read(int deviceId)
        {
            var certainDevice = _automationlaboratorydbContext.Devices.FirstOrDefault(cd => cd.Id == deviceId);
            return certainDevice;
        }

        public Device SetStatusFalse(Device device)
        {
            _automationlaboratorydbContext.Devices.Update(device);
            _automationlaboratorydbContext.SaveChanges();
            return device;
        }

        public Device SetStatusTrue(Device device)
        {
            _automationlaboratorydbContext.Devices.Update(device);
            _automationlaboratorydbContext.SaveChanges();
            return device;
        }

        public Device Update(Device device)
        {
            _automationlaboratorydbContext.Devices.Update(device);
            _automationlaboratorydbContext.SaveChanges();
            return device;
        }

        public void Delete(Device device)
        {
            _automationlaboratorydbContext.Devices.Remove(device);
            _automationlaboratorydbContext.SaveChanges();
        }
    }
}
