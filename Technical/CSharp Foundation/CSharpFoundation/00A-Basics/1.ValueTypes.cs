using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter1
{
    /*This program demonstrates the use of Value Types in C#*/
    public class ValueTypes
    {
        //Defines a struct.
        struct Person
        {
            public string firstName;
            public string lastName;
            public int age;
            public Gender gender;
        }

        //Define an Enumeration
        public enum Gender
        {
            Male,
            Female
        }

        public static void Display()
        {
            Console.WriteLine("\n****Value Types*****");

            byte myByte = 225; //Values are between 0 - 255
            Console.WriteLine(myByte.ToString());

            sbyte mySByte = -100; //Values are between -128 to 127
            Console.WriteLine(mySByte.ToString());

            int myInt = 2200; //An integer variable.
            Console.WriteLine(myInt.ToString());

            //Use the struct type.
            Person myPerson = new Person();
            myPerson.firstName = "Siva";
            myPerson.lastName = "Kumar";
            myPerson.age = 35;
            myPerson.gender = Gender.Male; //The gender property is an enumeration

            Console.WriteLine(myPerson.firstName + " " + myPerson.lastName + "; Age " + myPerson.age);
            Console.WriteLine(myPerson.firstName + " is a  " + myPerson.gender.ToString());

            //Using a Nullable type
            Nullable<bool> isGood = null;
            if(isGood==null)
            {
                isGood=true;
                Console.WriteLine(isGood.ToString()); //Displays true
            }
        }
    }
}
