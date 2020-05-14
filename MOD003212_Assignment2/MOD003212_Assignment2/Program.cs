using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MOD003212_Assignment2
{
    class Program
    {
        private static Random rand = new Random();
        private const int MIN_CREATION_INTERVAL = 1500;
        private const int MAX_CREATION_INTERVAL = 10000;
        private static Timer vehicleCreationTimer = new Timer();
        private static Timer maintainPumpsTimer = new Timer();
        private static Timer displayTimer = new Timer();
        static void Main(string[] args)
        {
            Vehicle.Setup();
            Pump.Initialise();
            SetVehicleCreationTimer();
            SetDisplayTimer();
            SetMaintainPumpsTimer();
            Console.ReadLine();
            vehicleCreationTimer.Stop();
            displayTimer.Stop();
            maintainPumpsTimer.Stop();
            vehicleCreationTimer.Dispose();
            displayTimer.Dispose();
            maintainPumpsTimer.Dispose();
        }
        //private static void testVehicles()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Vehicle vehicle = new Vehicle();
        //        Console.WriteLine("Vehicle type: {0}    Fuel type:{1}   Vehicle ID:{2}", vehicle.GetVehicleType(), vehicle.GetFuelType(), vehicle.GetVehicleID());
        //    }
        //}
        private static void SetVehicleCreationTimer()
        {
            vehicleCreationTimer.Interval = rand.Next(MIN_CREATION_INTERVAL, MAX_CREATION_INTERVAL + 1);
            vehicleCreationTimer.AutoReset = true;
            vehicleCreationTimer.Elapsed += createVehicle;
            vehicleCreationTimer.Start();
        }

        private static void createVehicle(object sender, ElapsedEventArgs e)
        {
            Vehicle vehicle = new Vehicle();
            //Console.WriteLine("Vehicle type: {0}    Fuel type:{1}   Vehicle ID:{2}", vehicle.GetVehicleType(), vehicle.GetFuelType(), vehicle.GetVehicleID());
            //Display.UpdateDisplay();
            vehicleCreationTimer.Interval = rand.Next(MIN_CREATION_INTERVAL, MAX_CREATION_INTERVAL + 1);
        }

        private static void SetMaintainPumpsTimer()
        {
            maintainPumpsTimer.Interval = 200;
            maintainPumpsTimer.AutoReset = true;
            maintainPumpsTimer.Elapsed += maintainPumps;
            maintainPumpsTimer.Start();
        }

        private static void maintainPumps(object sender, ElapsedEventArgs e)
        {
            Vehicle.CheckForPumps();
        }

        private static void SetDisplayTimer()
        {
            displayTimer.Interval = 500;
            displayTimer.AutoReset = true;
            displayTimer.Elapsed += updateDisplay;
            displayTimer.Start();
        }

        private static void updateDisplay(object sender, ElapsedEventArgs e)
        {
            Display.UpdateDisplay();
        }
    }
}

