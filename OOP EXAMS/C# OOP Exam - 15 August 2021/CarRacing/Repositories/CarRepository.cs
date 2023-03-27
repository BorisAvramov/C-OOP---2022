using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {

        private readonly List<ICar> models;


        public CarRepository()
        {
            models = new List<ICar>();
        }


        public IReadOnlyCollection<ICar> Models => models.AsReadOnly();

        public ICar First { get; internal set; }

        public void Add(ICar model)
        {
            if (model is null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }
            models.Add(model);
        }

        public ICar FindBy(string property)
        {
            return models.FirstOrDefault(m => m.VIN == property);

        }

        public bool Remove(ICar model)
        {

            return models.Remove(model);
        }
    }
}
