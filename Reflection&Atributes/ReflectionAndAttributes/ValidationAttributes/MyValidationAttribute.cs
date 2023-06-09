﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class MyValidationAttribute : Attribute
    {

        public abstract bool IsValid(object obj);
      
    }
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj) => obj != null;

    }
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }
        public override bool IsValid(object obj)
        {
            int currValue = (int)obj;
            return currValue >= minValue && currValue <= maxValue;
        }
    }


}
