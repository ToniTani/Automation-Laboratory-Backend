using Automation_Laboratory_Backend.Models;
using Automation_Laboratory_Backend.Repositories;
using System.Collections.Generic;

namespace Automation_Laboratory_Backend.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }
        public Device Create(Device device)
        {
            return _deviceRepository.Create(device);
        }

        public List<Device> Read()
        {
            return _deviceRepository.Read();
        }

        public List<Device> ReadIsActiveFalse()
        {
            return _deviceRepository.ReadIsActiveFalse();
        }

        public Device Read(int deviceId)
        {
            return _deviceRepository.Read(deviceId);
        }

        public Device SetStatusFalse(int deviceId)
        {
            var device = Read(deviceId);
            device.IsActive = false;
            return _deviceRepository.SetStatusFalse(device);
        }

        public Device SetStatusTrue(int deviceId)
        {
            var device = Read(deviceId);
            device.IsActive = true;
            return _deviceRepository.SetStatusTrue(device);
        }

        public Device Update(Device device)
        {
            return _deviceRepository.Update(device);
        }

        public void Delete(int deviceId)
        {
            Device deleteDevice = _deviceRepository.Read(deviceId);
            _deviceRepository.Delete(deleteDevice);
        }
    }
}
