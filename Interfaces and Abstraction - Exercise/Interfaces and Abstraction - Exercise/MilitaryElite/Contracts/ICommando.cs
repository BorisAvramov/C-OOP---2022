using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        public ICollection <IMission> Missions { get; set; }

        public void CompleteMission(string codeName);



    }
}
