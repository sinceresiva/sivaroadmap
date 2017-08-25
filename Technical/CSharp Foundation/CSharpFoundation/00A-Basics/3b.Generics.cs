using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//The program demonstrates the use of Generics and the constraints that
//can be used while specifying those generics.
namespace Chapter1
{
    public interface ITransport
    {
        string GetTravelMode();
    }

    public class Bus : ITransport
    {
        public virtual string GetTravelMode()
        {
            return("Travelling by Bus...");
        }
    }

    public class Cab : ITransport
    {
        public string GetTravelMode()
        {
            return("Travelling by Cab...");
        }
    }

    public class CompanyBus : Bus
    {
        public override string GetTravelMode()
        {
            return ("Travelling by CompanyBus...");
        }
    }

    public class GenericTransport
        
    {
        public GenericTransport()
        {
            Console.WriteLine("\n****Generics Example");
        }

        //The parameter <T> is the generic type.
        //The constraint where T: ITransport specifies an Interface constraint.
        //The constraint new() is required so as to create an instance of the 
        //generic type, else would lead to a compile time error.
        public void PrintTransportMode<T>()
            where T : ITransport, new()
        {
            T transport = new T();
            Console.WriteLine(transport.GetTravelMode());
        }

        //The constraint where T: Bus defines a Base Class constraint.
        //Hence only Bus instanaces and those derived from Bus can be
        //used to this method.
        public void PrintBusTransportMode<T>()
            where T : Bus, new()
        {
            T transport = new T();
            Console.WriteLine(transport.GetTravelMode());
        }


    }
}
