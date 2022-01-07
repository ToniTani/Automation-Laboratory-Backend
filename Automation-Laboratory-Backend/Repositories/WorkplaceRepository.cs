using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Automation_Laboratory_Backend.Models;

namespace Automation_Laboratory_Backend.Repositories
{
    public class WorkplaceRepository : IWorkplaceRepository
    {
        private readonly AutomationlaboratorydbContext _automationlaboratorydbContext;

        public WorkplaceRepository(AutomationlaboratorydbContext automationlaboratorydbContext)
        {
            _automationlaboratorydbContext = automationlaboratorydbContext;
        }

        public Workplace Create(Workplace workplace)
        {
            _automationlaboratorydbContext.Workplaces.Add(workplace);
            _automationlaboratorydbContext.SaveChanges();
            return workplace;
        }

        public List<Workplace> Read()
        {
            var everyWorkplace = _automationlaboratorydbContext.Workplaces.ToList();
            return everyWorkplace;
        }

        public Workplace Read(int workplaceId)
        {
            var certainWorkplace = _automationlaboratorydbContext.Workplaces.FirstOrDefault(cw => cw.Id == workplaceId);
            return certainWorkplace;
        }

        public Workplace Update(Workplace workplace)
        {
            _automationlaboratorydbContext.Workplaces.Update(workplace);
            _automationlaboratorydbContext.SaveChanges();
            return workplace;
        }
    }
}