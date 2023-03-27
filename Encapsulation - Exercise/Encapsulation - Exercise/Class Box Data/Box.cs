using System;
using System.Collections.Generic;
using System.Text;

namespace Box
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height )
        {

            Length = length;
            Width = width;
            Height = height;
           
            
        }

        public double Height
        {
            get { return height; }
            private set 
            {
                string prop = "Height";
                Validator.IsValidProp(prop, value);
                height = value; 
            }
        }


        public double Width
        {
            get { return width; }
           private set 
            {
                string prop = "Width";
                Validator.IsValidProp(prop, value);

                width = value;
            
            
            }
        }

        

        public double Length
        {
            get { return  length; }
           private set 
            {
                string prop = "Length";
                Validator.IsValidProp(prop, value);
                length = value; 
            
            
            }
        }

        //Surface Area = 2lw + 2lh + 2wh

        public double SurfaceArea()
        {
            return 2 * Length * Width + 2 * length * height + 2 * width * height;

        }

        //Lateral Surface Area = 2lh + 2wh

        public double LateralSurfaceArea()
        {

            return 2 * length * height + 2 * width * height;

        }

        //Volume = lwh

        public double Volume()
        {
            return length * width * height;
        }
    }
}
