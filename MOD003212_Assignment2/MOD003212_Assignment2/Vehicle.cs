using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MOD003212_Assignment2
{
    class Vehicle
    {
        private static Random rand = new Random();
        /// <summary>
        /// The queue of vehicles currently waiting for a pump
        /// </summary>
        private static Queue<Vehicle> waitingVehicles = new Queue<Vehicle>();
        private static int nextVehicleID = 1;
        private static Vehicle temp;

        /// <summary>
        /// Stores vehicle types againt numbers to make vehicle generation easier
        /// https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2.-ctor?view=netframework-4.8
        /// Accessed 24/04/2020
        /// </summary>
        public static Dictionary<int, string> vehicleTypes = new Dictionary<int, string>(3);
        public static Dictionary<int, string> fuelTypes = new Dictionary<int, string>(3);
        public static void Setup()
        {
            vehicleTypes.Add(0, "Car");
            vehicleTypes.Add(1, "Van");
            vehicleTypes.Add(2, "HGV");
            fuelTypes.Add(0, "Unleaded");
            fuelTypes.Add(1, "Diesel");
            fuelTypes.Add(2, "LPG");
        }
        private string vehicleType = "";
        private string fuelType = "";
        private int vehicleID = 0;
        private Timer waitingTime = new Timer();

        public Vehicle()
        {
            vehicleID = nextVehicleID;
            vehicleType = vehicleTypes[rand.Next(0, 3)];
            fuelType = fuelTypes[rand.Next(0, 3)];
            waitingTime.Interval = 1500;
            waitingTime.AutoReset = false;
            waitingTime.Elapsed += WaitingTime_Elapsed;

            if (waitingVehicles.Count == 0)
            {
                waitingVehicles.Enqueue(this);
                waitingTime.Start();
            }
            nextVehicleID++;
            //string dateTime = Convert.ToString(DateTime.Now);
            //string time = dateTime.Substring(11, 8);
            //Console.WriteLine(time);
        }

        private void WaitingTime_Elapsed(object sender, ElapsedEventArgs e)
        {
            //this will need changing when multiple vehicles are allowed in the queue
            waitingVehicles.Dequeue();
            Counters.IncrementVehiclesLeft();
            waitingTime.Stop();
            waitingTime.Dispose();
        }

        public string GetVehicleType()
        {
            return vehicleType;
        }
        public int GetVehicleID()
        {
            return vehicleID;
        }
        public string GetFuelType()
        {
            return fuelType;
        }

        public static Queue<Vehicle> GetVehicles()
        {
            return waitingVehicles;
        }

        public static void CheckForPumps()
        {
            if (waitingVehicles.Count > 0)
            {
                //start with the first lane, then check the others
                for (int i = 0; i < 3; i++)
                {
                    if (!(Pump.pumps[i, 0].IsOccupied()))
                    {
                        if (!(Pump.pumps[i, 1].IsOccupied()))
                        {
                            //if all 3 pumps are free and there is a vehicle in the queue
                            if (!(Pump.pumps[i, 2].IsOccupied()) && waitingVehicles.Count > 0)
                            {
                                //move the vehicle into the 3rd pump
                                temp = waitingVehicles.Dequeue();
                                temp.waitingTime.Stop();
                                temp.waitingTime.Dispose();
                                Pump.pumps[i, 2].IsNowOccupied(temp);
                            }
                            //if the first 2 are free but not the 3rd and there is a vehicle in the queue
                            else if (Pump.pumps[i, 2].IsOccupied() && waitingVehicles.Count > 0)
                            {
                                //move the vehicle into the 2nd pump
                                temp = waitingVehicles.Dequeue();
                                temp.waitingTime.Stop();
                                temp.waitingTime.Dispose();
                                Pump.pumps[i, 1].IsNowOccupied(temp);
                            }
                        }
                        //if the first is free but not the 2nd and there is a vehicle in the queue
                        else if (Pump.pumps[i, 1].IsOccupied() && waitingVehicles.Count > 0)
                        {
                            //move the vehicle into the 1st pump
                            temp = waitingVehicles.Dequeue();
                            temp.waitingTime.Stop();
                            temp.waitingTime.Dispose();
                            Pump.pumps[i, 0].IsNowOccupied(temp);
                        }
                    }
                }
            }
        }
    }
}

