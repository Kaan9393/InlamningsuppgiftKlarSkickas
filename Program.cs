using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Test99InlämingKlarMETOD
{
    class Program
    {
        static Random rnd = new Random();
        static List<Boat> dock = new List<Boat>();
        static List<Boat> dissmissedBoats = new List<Boat>();
        static Harbor harbor = new Harbor();
        static int IncommingBoatAday = 5;
        static int day = 0;
        static double slotsTaken = 0;


        static void Main(string[] args)
        { 
            //Läser från filen: 
            ReadFromFile();

            harbor.Slots = 64.0;
            harbor.AmountSlotBlocked = new List<Location>();

            while (true)
            {
                day++;

                Console.WriteLine($"----------------DAG: {day}----------------");
                Console.WriteLine($"BoatType\tID\tWeight\tMaxSpeed\tOther\t");

                
                LoopRandomBoatsAndAddToList();                                                   //Hämtar 5 random båtar per dag, lägger in dem i listan + ökar på antal tagna platser.

                WriteBoatsFromDock();                                                                      //Utskriften av båtarna:

                SumAndAverageLINQ();                                                                     //Summering av Vikt, Average Speed och dissmissed boats.

                Console.WriteLine($"[[SLOTS TAKEN THIS DAY {slotsTaken}]]");

                BoatsLeaveDock();                                                                             //När båtarna lämnar listan och minskar antal tagna platser

                ReadToFile();                                                                                       //Skriver till Texfilen:

                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void LoopRandomBoatsAndAddToList()
        {
            for (int i = 0; i < IncommingBoatAday; i++)
            {

                int randomBoat = rnd.Next(1, 5);

                switch (randomBoat)
                {
                    case 1:
                        Rowingboat newRowingboat = new Rowingboat("Rowingboat", "R-", RandomID(), rnd.Next(100, 300), rnd.Next(1, 3), 0.5, 1, "PAX:", rnd.Next(1, 6));

                        if ((slotsTaken + newRowingboat.BoatSize) < harbor.Slots)
                        {
                            slotsTaken += newRowingboat.BoatSize;
                            dock.Add(newRowingboat);

                            //Båtar som får plats i Listan, använder denna Lista för att sedan ta bort båtarna genom deras ID och inte platsen i listan
                            harbor.AmountSlotBlocked.Add(new Location { ID = newRowingboat.IdNum, LocationSlotSize = newRowingboat.BoatSize });
                        }

                        else
                        {
                            //Båtar som inte får plats
                            dissmissedBoats.Add(newRowingboat);
                        }
                        break;

                    case 2:
                        Speedboat newSpeedboat = new Speedboat("Speedboat", "M-", RandomID(), rnd.Next(200, 3000), rnd.Next(1, 6), 1.0, 3, "HK:", rnd.Next(10, 1000));
                        if ((slotsTaken + newSpeedboat.BoatSize) < harbor.Slots)
                        {
                            slotsTaken += newSpeedboat.BoatSize;
                            dock.Add(newSpeedboat);

                            //Båtar som får plats i Listan, använder denna Lista för att sedan ta bort båtarna genom deras ID och inte platsen i listan
                            harbor.AmountSlotBlocked.Add(new Location { ID = newSpeedboat.IdNum, LocationSlotSize = newSpeedboat.BoatSize });
                        }
                        else
                        {
                            //Båtar som inte får plats
                            dissmissedBoats.Add(newSpeedboat);
                        }
                        break;

                    case 3:
                        Sailboat newSailboat = new Sailboat("Sailboat", "S-", RandomID(), rnd.Next(800, 6000), rnd.Next(1, 12), 2.0, 4, "Length:", rnd.Next(10, 60));
                        if ((slotsTaken + newSailboat.BoatSize) < harbor.Slots)
                        {
                            slotsTaken += newSailboat.BoatSize;
                            dock.Add(newSailboat);

                            //Båtar som får plats i Listan, använder denna Lista för att sedan ta bort båtarna genom deras ID och inte platsen i listan.
                            harbor.AmountSlotBlocked.Add(new Location { ID = newSailboat.IdNum, LocationSlotSize = newSailboat.BoatSize });
                        }
                        else
                        {
                            //Båtar som inte får plats
                            dissmissedBoats.Add(newSailboat);
                        }
                        break;

                    case 4:
                        Cargoship newCargoship = new Cargoship("Cargoship", "L-", RandomID(), rnd.Next(3000, 20000), rnd.Next(1, 20), 4.0, 6, "Cont:", rnd.Next(1, 500));
                        if ((slotsTaken + newCargoship.BoatSize) < harbor.Slots)
                        {
                            slotsTaken += newCargoship.BoatSize;
                            dock.Add(newCargoship);

                            //Båtar som får plats i Listan, använder denna Lista för att sedan ta bort båtarna genom deras ID och inte platsen i listan.
                            harbor.AmountSlotBlocked.Add(new Location { ID = newCargoship.IdNum, LocationSlotSize = newCargoship.BoatSize });
                        }
                        else
                        {
                            //Båtar som inte får plats
                            dissmissedBoats.Add(newCargoship);
                        }
                        break;

                    default:
                        break;
                }

            }
        }
        public static void WriteBoatsFromDock()
        {
            foreach (var item in dock)
            {
                if (item.GetType() == typeof(Rowingboat))
                {
                    var rowingboat = (Rowingboat)item;
                    Console.WriteLine($"{rowingboat.BoatType}\t{rowingboat.RandomString}{rowingboat.IdNum}\t{rowingboat.Weight}\t{rowingboat.Speed}\t\t{rowingboat.PassengerString}{rowingboat.Passenger}\t");
                }

                if (item.GetType() == typeof(Speedboat))
                {
                    var speedboat = (Speedboat)item;
                    Console.WriteLine($"{speedboat.BoatType}\t{speedboat.RandomString}{speedboat.IdNum}\t{speedboat.Weight}\t{speedboat.Speed}\t\t{speedboat.horsePowerString}{speedboat.HorsePower}\t");
                }

                if (item.GetType() == typeof(Sailboat))
                {
                    var sailboat = (Sailboat)item;
                    Console.WriteLine($"{sailboat.BoatType}\t{sailboat.RandomString}{sailboat.IdNum}\t{sailboat.Weight}\t{sailboat.Speed}\t\t{sailboat.LenghtString}{sailboat.Lenght}\t");
                }

                if (item.GetType() == typeof(Cargoship))
                {
                    var cargoship = (Cargoship)item;
                    Console.WriteLine($"{cargoship.BoatType}\t{cargoship.RandomString}{cargoship.IdNum}\t{cargoship.Weight}\t{cargoship.Speed}\t\t{cargoship.ContainersString}{cargoship.Containers}\t");
                }
            }
        }
        public static void SumAndAverageLINQ()
        {
            var q1 = dock
                    .Select(b => b.Weight)
                    .Sum();
            Console.WriteLine($"Total Weight: {q1}");


            var q2 = dock
                .Select(b => b.Speed)
                .Average();
            Console.WriteLine($"Average Speed: {q2:N2}");

            var q3 = dissmissedBoats
                .GroupBy(b => b.BoatType);
            int countDissBoats = 0;
            foreach (var item in q3)
            {
                countDissBoats += item.Count();
            }
            Console.WriteLine($"Dissmissed Boats: {countDissBoats}");
        }

        public static void BoatsLeaveDock()
        {
            foreach (var item in dock.ToList())
            {
                //--item.BoatDay;

                if (item.BoatDay == 0)
                {
                    Console.WriteLine("*******************************************");
                    Console.WriteLine("Båt som har lämnat idag");
                    Console.WriteLine($"{item.BoatType} {item.IdNum}");

                    dock.Remove(item);
                    slotsTaken -= item.BoatSize;

                    Location itemToRemove = harbor.AmountSlotBlocked
                        .Where(b => b.ID == item.IdNum)
                        .FirstOrDefault();


                    //Item to REMOVE
                    harbor.AmountSlotBlocked.Remove(itemToRemove);
                }
                --item.BoatDay;
            }
        }

        public static void ReadToFile()
        {
            using StreamWriter sw = new StreamWriter("data.txt", false);
            sw.WriteLine($"{day};{slotsTaken}"); //;{dissmissedBoats}

            foreach (var item in dock)
            {

                if (item.GetType() == typeof(Rowingboat))
                {
                    var rowingboat = (Rowingboat)item;
                    sw.WriteLine($"{rowingboat.BoatType};{rowingboat.RandomString};{rowingboat.IdNum};{rowingboat.Weight};{rowingboat.Speed};{rowingboat.BoatSize};{rowingboat.BoatDay};{rowingboat.PassengerString};{rowingboat.Passenger}");
                }

                if (item.GetType() == typeof(Speedboat))
                {
                    var speedboat = (Speedboat)item;
                    sw.WriteLine($"{speedboat.BoatType};{speedboat.RandomString};{speedboat.IdNum};{speedboat.Weight};{speedboat.Speed};{speedboat.BoatSize};{speedboat.BoatDay};{speedboat.horsePowerString};{speedboat.HorsePower}");
                }

                if (item.GetType() == typeof(Sailboat))
                {
                    var sailboat = (Sailboat)item;
                    sw.WriteLine($"{sailboat.BoatType};{sailboat.RandomString};{sailboat.IdNum};{sailboat.Weight};{sailboat.Speed};{sailboat.BoatSize};{sailboat.BoatDay};{sailboat.LenghtString};{sailboat.Lenght}");
                }

                if (item.GetType() == typeof(Cargoship))
                {
                    var cargoship = (Cargoship)item;
                    sw.WriteLine($"{cargoship.BoatType};{cargoship.RandomString};{cargoship.IdNum};{cargoship.Weight};{cargoship.Speed};{cargoship.BoatSize};{cargoship.BoatDay};{cargoship.ContainersString};{cargoship.Containers}");
                }

            }
            sw.Close();
        }

        public static void ReadFromFile()
        {
            if (File.Exists("data.txt"))
            {
                var textFile = File.ReadAllLines("data.txt");
                int counter = 0;
                foreach (string aboat in textFile)
                {
                    if (counter == 0)
                    {
                        string[] boatData = aboat.Split(';');
                        day = int.Parse(boatData[0]);

                        slotsTaken = double.Parse(boatData[1]);

                        counter++;
                    }

                    if (aboat.Length > 1)
                    {
                        string[] boatData = aboat.Split(';');

                        switch (boatData[1])            
                        {
                            case "R-":
                                Rowingboat rowingboat1 = new Rowingboat(boatData[0], boatData[1], boatData[2], int.Parse(boatData[3]), int.Parse(boatData[4]), double.Parse(boatData[5]), int.Parse(boatData[6]), boatData[7], int.Parse(boatData[8]));
                                dock.Add(rowingboat1);
                                break;
                            case "S-":
                                Sailboat sailboat1 = new Sailboat(boatData[0], boatData[1], boatData[2], int.Parse(boatData[3]), int.Parse(boatData[4]), double.Parse(boatData[5]), int.Parse(boatData[6]), boatData[7], int.Parse(boatData[8]));
                                dock.Add(sailboat1);
                                break;
                            case "M-":
                                Speedboat speedboat1 = new Speedboat(boatData[0], boatData[1], boatData[2], int.Parse(boatData[3]), int.Parse(boatData[4]), double.Parse(boatData[5]), int.Parse(boatData[6]), boatData[7], int.Parse(boatData[8]));
                                dock.Add(speedboat1);
                                break;
                            case "L-":
                                Cargoship cargoship1 = new Cargoship(boatData[0], boatData[1], boatData[2], int.Parse(boatData[3]), int.Parse(boatData[4]), double.Parse(boatData[5]), int.Parse(boatData[6]), boatData[7], int.Parse(boatData[8]));
                                dock.Add(cargoship1);
                                break;
                            default:
                                break;
                        }

                    }
                }
            }
            else
            {

            }
        }


        //Metod för att skapa Random ID för båtarna:
        static string RandomID()
        {
            Random randomID = new Random();
            string b = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int length = 3;
            string random = "";

            for (int i = 0; i < length; i++)
            {
                int a = randomID.Next(26);
                random = random + b.ElementAt(a);
            }
            return random;
        }
    }
}
