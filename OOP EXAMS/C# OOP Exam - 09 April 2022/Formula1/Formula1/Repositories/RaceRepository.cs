using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    internal class RaceRepository : IRepository<IRace>
    {

        private readonly List<IRace> models;


        public RaceRepository()
        {
            models = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models => models.AsReadOnly();

        public void Add(IRace model)
        {
            models.Add(model);
        }

        public IRace FindByName(string name)
        {
            var race = models.FirstOrDefault(r => r.RaceName == name);
            return race;
        }

        public bool Remove(IRace model)
        {
            return models.Remove(model);

        }
    }
}
