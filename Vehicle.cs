using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiadotNET
{
    class Vehicle : IEquatable<Vehicle>
    {
        public string brand { get; set; }
        public string model { get; set; }
        public string registractionNumber { get; set; }
        public int yearOfProduction { get; set; }

        public Vehicle()
        {
            brand = "default brand";
            model = "default model";
            registractionNumber = "default registraction number";
            yearOfProduction = 0;
        }

        public Vehicle(string oBrand, string oModel, string oRegistractionNumber, int oYearOfProduction)
        {
            brand = oBrand;
            model = oModel;
            registractionNumber = oRegistractionNumber;
            yearOfProduction = oYearOfProduction;
        }

        public override string ToString()
        {
            return this.brand + " " + this.model + " ,"+this.yearOfProduction;
        }

        public bool Equals(Vehicle item)
        {
            return (item.registractionNumber == registractionNumber);
        }
    }
}
