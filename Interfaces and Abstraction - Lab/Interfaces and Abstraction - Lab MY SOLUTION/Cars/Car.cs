using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Car : ICar
    {
        public Car(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Model { get; private set; }
        public string Color { get;private set; }

        public string Start()
        {
            return $"Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            //Grey Seat Leon
            return $"{this.Color} {this.GetType().Name} {this.Model}";
        }
    }
}
