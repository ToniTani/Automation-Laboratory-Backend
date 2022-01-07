using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Automation_Laboratory_Backend.Models;

namespace Automation_Laboratory_Backend.Repositories
{
    public interface IDeviceRepository
    {
        Device Create(Device device);
        List<Device> Read();
        List<Device> ReadIsActiveFalse();
        Device Read(int deviceId);
        Device Update(Device device);
        Device SetStatusFalse(Device device);
        Device SetStatusTrue(Device device);
        void Delete(Device device);
    }
}
