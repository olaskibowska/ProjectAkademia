using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiadotNET
{
    class Bus :Vehicle
    {
        public int numberOfSeats;
        public Bus()
        {
            numberOfSeats = 0;
        }
        public Bus(string oBrand, string oModel, string oRegistractionNumber, int oYearOfProduction, int oNumberOfSeats) : base(oBrand,oModel,oRegistractionNumber,oYearOfProduction)
        {
            numberOfSeats = oNumberOfSeats;
        }
        override public string Description()
        {
            return "Marka: " + brand +
                "\n" + "Model: " + model +
                "\n" + "Nr rejestracyjny: " + registractionNumber +
                "\n" + "Rok produkcji: " + yearOfProduction +
                "\n" + "Liczba siedzen dla pasazerow: " + numberOfSeats;
        }
    }
}
