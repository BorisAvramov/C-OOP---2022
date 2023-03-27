using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private List<IVessel> models = new List<IVessel>();
        public IReadOnlyCollection<IVessel> Models { get => models.AsReadOnly(); }

        public void Add(IVessel model)
        {
            this.models.Add(model);
        }

        public IVessel FindByName(string name)
        {
            var vessel = this.Models.FirstOrDefault(v => v.Name == name);

            return vessel;
        }

        public bool Remove(IVessel model)
        {
            var vesselToBeRemoved = this.Models.FirstOrDefault(v => v.Name == model.Name);
            if(vesselToBeRemoved == null)
            {
                return false;
            }
            else
            {
                this.models.Remove(vesselToBeRemoved);
                return true;
            }
        }
    }
}
