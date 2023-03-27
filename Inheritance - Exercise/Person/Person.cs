using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
            if (this.age < 0)
            {
                throw new Exception("Invalid age under 0 years old");
            }
        }

        public int Age => age;
        public string Name => name;

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }


        //public int Age 
        //{ 
        //    get {return age; } 
            
            
        //    set {


        //        if (age < 0 )
        //        {
        //            throw new Exception();
        //        }
        //        age = value ; 
            
            
        //        }
        
       
        
        //}
        //public string Name { get {return name; } set { name = value ; } }

    }
}
