using Automation_Laboratory_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Automation_Laboratory_Backend.Repositories;

namespace Automation_Laboratory_Backend.Services
{
    public class WorkplaceService : IWorkplaceService
    {
        private readonly IWorkplaceRepository _workplaceRepository;

        public WorkplaceService(IWorkplaceRepository workplaceRepository)
        {
            _workplaceRepository = workplaceRepository;
        }

        public Workplace Create(Workplace workplace)
        {
            return _workplaceRepository.Create(workplace);
        }

        public List<Workplace> Read()
        {
            return _workplaceRepository.Read();
        }

        public Workplace Read(int workplaceId)
        {
            return _workplaceRepository.Read(workplaceId);
        }

        public Workplace Update(Workplace workplace)
        {
            return _workplaceRepository.Update(workplace);
        }
    }
}
