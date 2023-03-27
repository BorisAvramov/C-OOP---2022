using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
           this.Privates = new List<IPrivate>();

        }

        public ICollection<IPrivate> Privates { get; set; }

        //public void AddPrivate(IPrivate @private)
        //{
            
        //    Privates.Add(@private);

        //}
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");
            foreach (IPrivate priv in Privates)
            {
                sb.AppendLine($"  {priv.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
