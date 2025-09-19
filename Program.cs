﻿using System;
using System.Threading;

namespace ultimaterace
{
    class Program
    {
        static int numberofcontents = 6;
        static Thread[] contestent = new Thread[numberofcontents];
        static int currentcontestent = 0;
        static Scoreboard scoreboard = new Scoreboard();
        static Vehicle vehicle = new Vehicle();
        static Random random = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME!!!");
            Thread.Sleep(1000);
            Console.WriteLine("To the ULTIMATE RACE!!!");
            Thread.Sleep(1000);
            Console.WriteLine("Travel from Cairo to Cape Town.");
            Thread.Sleep(1000);
            Console.Write("A journey of blood");
            Thread.Sleep(1000);
            Console.Write(", sweat");
            Thread.Sleep(1000);
            Console.WriteLine(", and gears!");
            Thread.Sleep(1000);
            Console.WriteLine("Gentlemen, start your engine!");
            Thread.Sleep(1000);
            Console.WriteLine("3");
            Thread.Sleep(1000);
            Console.WriteLine("2");
            Thread.Sleep(1000);
            Console.WriteLine("1");
            Console.WriteLine("Go!!!!");
            Thread.Sleep(1000);

            for (int i = 0; i < numberofcontents; i++)
            {
                contestent[i] = new Thread(HandleThreadStart);
                contestent[i].Start();
            }

            int position = 0;
            bool bikehaswon, teslahaswon, subhaswon, chopperstopped;
            bikehaswon = teslahaswon = subhaswon = chopperstopped = false;

            while (true)
            {
                // different modes of transport can take shorter routes
                if (!bikehaswon && scoreboard.bikeposition > scoreboard.bikedistancetotraveltowin)
                {
                    if (position == 0)
                    {
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!111");
                        Console.WriteLine("Bike has won!");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!111");
                    }
                    else
                    {
                        Console.WriteLine("Bike came " + position + "nd.");
                    }
                    contestent[1].Abort();
                    bikehaswon = true;

                } else if (!teslahaswon && scoreboard.teslapostion > scoreboard.tesladistancetotraveltowin)
                {
                    if (position == 0)
                    {
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!111");
                        Console.WriteLine("Tesla has won!");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!111");
                    }
                    else
                    {
                        Console.WriteLine("Tesla came " + position + "nd.");
                    }
                   contestent[2].Abort();
                    teslahaswon = true;
                    
                } else if (!bikehaswon && scoreboard.chopperposition > scoreboard.chopperposition)
                {
                    if (position == 0)
                    {
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!111");
                        Console.WriteLine("Chopper has won!");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!111");
                    }
                    else
                    {
                        Console.WriteLine("Chopper came " + position + "nd.");
                    }
                    contestent[0].Abort();
                    chopperstopped = true;
                    
                } else if (!subhaswon && scoreboard.subposition > scoreboard.subdistancetotraveltowin)
                {
                    if (position == 0)
                    {
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!111");
                        Console.WriteLine("Nuclear sub has won!");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!111");
                    }
                    else
                    {
                        Console.WriteLine("Nuclear sub came " + position + "nd.");
                    }
                    contestent[1].Abort();
                    subhaswon = true;
                }

                // Every second represents an hour
                Thread.Sleep(1000);
                Console.WriteLine("\n------------------\n");
            }
        }

        protected static void HandleThreadStart() {
            if (currentcontestent == 0) {
                currentcontestent++;
                StartChopper();
            }
            else if (currentcontestent == 1)
            {
                currentcontestent++;
                StartBike();
            }
            else if (currentcontestent == 2)
            {
                currentcontestent++;
                StartTesla();
            }
            else if (currentcontestent == 3)
            {
                currentcontestent++;
                StartNuclearSub();
            }
        }

        private static void StartNuclearSub()
        {
            scoreboard.subposition = 0;

            while (true)
            {
                Thread.Sleep(1000); // Every second represents an hour
                scoreboard.subposition = scoreboard.subposition + vehicle.nuclearsubspeedknots * 2;

                Console.WriteLine("Nuclear sub has travelled \t" + scoreboard.subposition + "km");

                if (random.NextDouble() < vehicle.subbreakdownprobability)
                {
                    int repairTime = (int)(random.NextDouble() / random.NextDouble() * 1000) + 1000; // Stop at least 1 hour
                    Console.WriteLine("Sub has broken down :(");
                    Console.WriteLine($"It will take " + (repairTime/1000).ToString() + "hrs to repair");
                    Thread.Sleep(repairTime);
                    Console.WriteLine("Sub is back in the water and in the race!!");
                }
            }
        }

        private static void StartChopper()
        {
            int time = 0;
            scoreboard.chopperposition = 0;
            int fuel = vehicle.chopperfuelcapacitygallons;

            while (true)
            {
                Thread.Sleep(1000);
                scoreboard.chopperposition = scoreboard.chopperposition + vehicle.chopperAvgSpeedkmh;
                Console.WriteLine("Chopper has travelled \t\t" + scoreboard.chopperposition + "km");
                fuel -= vehicle.chopperFuelUsageperhourgallons;

                if (fuel < 0)
                {
                    Console.WriteLine("Chopper out of fuel :(");
                    Thread.Sleep(vehicle.choppertimetorefuelhrs * 1000);
                    fuel = vehicle.chopperfuelcapacitygallons;
                    Console.WriteLine("Chopper is back in the air and in the race!!");
                }

               if (random.NextDouble() < vehicle.teslabreakdownprobability)
                {
                    int repairTime = (int)(random.NextDouble() / random.NextDouble() * 1000) + 1000; // Stop at least 1 hour
                    Console.WriteLine("Chopper has broken down :(");
                    Console.WriteLine($"It will take " + (repairTime / 1000).ToString() + "hrs to repair");
                    Thread.Sleep(repairTime);
                    Console.WriteLine("Chopper is back in the air and in the race!!");
                }
            }
        }

        private static void StartTesla()
        {
            double batteryLeft = vehicle.teslabatterypack;
            scoreboard.teslapostion = 0;

            while (true)
            {
                Thread.Sleep(1000);
                scoreboard.teslapostion = scoreboard.teslapostion + vehicle.teslaspeed;
                Console.WriteLine("Tesla has travelled \t\t" + scoreboard.teslapostion + "km");
                batteryLeft -= vehicle.teslaenginekw;

                if (batteryLeft < 0)
                {
                    Console.WriteLine("Tesla out of battery :(");
                    Thread.Sleep((int)vehicle.teslatimetorefuelhrs * 1000);
                    batteryLeft = vehicle.teslabatterypack;
                    Console.WriteLine("Tesla is back on the road and in the race!!");
                }

                if (random.NextDouble() < vehicle.teslabreakdownprobability)
                {
                    int repairTime = (int)(random.NextDouble() / random.NextDouble() * 1000) + 1000; // Stop at least 1 hour
                    Console.WriteLine("Tesla has broken down :(");
                    Console.WriteLine($"It will take " + (repairTime / 1000).ToString() + "hrs to repair");
                    Thread.Sleep(repairTime);
                    Console.WriteLine("Tesla is back on the road and in the race!!");
                }
            }
        }

        private static void StartBike()
        {
            scoreboard.bikeposition = 0;
            int fuel = (int) vehicle.bikefueltankliters;

            while (true)
            {
                Thread.Sleep(1000);
                scoreboard.bikeposition = scoreboard.bikeposition + (int) (vehicle.bikespeedmph * 1.6);
                Console.WriteLine("Bike has travellled \t\t" + scoreboard.bikeposition + "km");
                fuel -= (int)(vehicle.bikespeedmph / vehicle.bikekmperlitre);

                if (fuel < 0)
                {
                    Console.WriteLine("Bike out of fuel :(");
                    Thread.Sleep((int)(vehicle.biketimetorefuelhrs * 1000));
                    fuel = (int)vehicle.bikefueltankliters;
                    Console.WriteLine("Bike is back on the dirt tracks and in the race!!");
                }


                if (random.NextDouble() < vehicle.bikebreakdownprobability)
                {
                    int repairTime = (int)(random.NextDouble() / random.NextDouble() * 1000) + 1000; // Stop at least 1 hour
                    Console.WriteLine("Bike has broken down :(");
                    Console.WriteLine($"It will take {repairTime / 1000}hrs to repair");
                    Thread.Sleep(repairTime);
                    Console.WriteLine("Bike is back on the dirt tracks and in the race!!");
                }
            }
        }
    }
}