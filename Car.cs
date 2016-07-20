using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiadotNET
{
    enum airConditioningValue {Tak, Nie}
    class Car : Vehicle
    {
        public string airConditioning;
        private bool VintageCar;

        public Car()
        {
            airConditioning = "default air conditioning";
        }
        public Car(string oBrand, string oModel, string oRegistractionNumber, int oYearOfProduction, string oAirConditioning) : base(oBrand,oModel,oRegistractionNumber,oYearOfProduction)
        {
            airConditioning = oAirConditioning;
        }
            
        override public string Description()
        {
            return "Marka: " + brand +
                "\n" + "Model: " + model +
                "\n" + "Nr rejestracyjny: " + registractionNumber +
                "\n" + "Rok produkcji: " + yearOfProduction +
                "\n" + "Klimatyzacja: " + airConditioning;
        }

        public void SetVintageCar ()
        {
            DateTime today = DateTime.Today;
            int currentYear = today.Year;
            if(25 < currentYear-yearOfProduction)
            {
                VintageCar = true;
            }
            else
            {
                VintageCar = false;
            }
        }


        public string VintageCarDescription()
        {
            SetVintageCar();

            if (VintageCar)
            {
                return "Samochód zabytkowy!";
            }
            else
            {
                return " ";
            }
        }

    }
}
