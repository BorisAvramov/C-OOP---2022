using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {

        public ICollection<IPrivate> Privates { get; set; }

    }
}
