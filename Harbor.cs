using System;
using System.Collections.Generic;
using System.Text;

namespace Test99InlämingKlarMETOD
{
    class Harbor
    {
        public double Slots { get; set; }
        public List<Location> AmountSlotBlocked { get; set; }
    }

    class Location
    {
        public string ID { get; set; }
        public double LocationSlotSize { get; set; }
    }

    class Boat
    {
        public string BoatType { get; set; }
        public string RandomString { get; set; }
        public string IdNum { get; set; }
        public int Weight { get; set; }
        public int Speed { get; set; }
        public double BoatSize { get; set; }
        public int BoatDay { get; set; }
    }


    class Rowingboat : Boat
    {
        public int Passenger { get; set; }
        public string PassengerString { get; set; }

        public Rowingboat(string boatType, string randomstring, string idnum, int weight, int speed, double boatSize, int boatDay, string passengerString, int passenger)
        {
            BoatType = boatType;
            RandomString = randomstring;
            IdNum = idnum;
            Weight = weight;
            Speed = speed;
            BoatSize = boatSize;
            BoatDay = boatDay;
            PassengerString = passengerString;
            Passenger = passenger;

        }
    }

    class Speedboat : Boat
    {
        public int HorsePower { get; set; }
        public string horsePowerString { get; set; }

        public Speedboat(string boatType, string randomstring, string idnum, int weight, int speed, double boatSize, int boatDay, string horsepowerString, int horsepower)
        {
            BoatType = boatType;
            RandomString = randomstring;
            IdNum = idnum;
            Weight = weight;
            Speed = speed;
            BoatSize = boatSize;
            BoatDay = boatDay;
            horsePowerString = horsepowerString;
            HorsePower = horsepower;
        }
    }

    class Sailboat : Boat
    {
        public int Lenght { get; set; }
        public string LenghtString { get; set; }

        public Sailboat(string boatType, string randomstring, string idnum, int weight, int speed, double boatSize, int boatDay, string lenghtstring, int lenght)
        {
            BoatType = boatType;
            RandomString = randomstring;
            IdNum = idnum;
            Weight = weight;
            Speed = speed;
            BoatSize = boatSize;
            BoatDay = boatDay;
            LenghtString = lenghtstring;
            Lenght = lenght;
        }
    }

    class Cargoship : Boat
    {
        public int Containers { get; set; }
        public string ContainersString { get; set; }

        public Cargoship(string boatType, string randomstring, string idnum, int weight, int speed, double boatSize, int boatDay, string containersstring, int containers)
        {
            BoatType = boatType;
            RandomString = randomstring;
            IdNum = idnum;
            Weight = weight;
            Speed = speed;
            BoatSize = boatSize;
            BoatDay = boatDay;
            Containers = containers;
            ContainersString = containersstring;
        }
    }
}
