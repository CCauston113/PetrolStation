using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;

namespace MOD003212_Assignment2
{
    class Pump
    {
        public static Pump[,] pumps = new Pump[3, 3];
        private static Random rand = new Random();
        private const int MIN_FUEL_TIME = 17000;
        private const int MAX_FUEL_TIME = 19000;

        private int pumpNo;
        private bool occupied = false;
        /// <summary>
        /// The time it will take for the vehicle to get fuel
        /// </summary>
        private Timer fuellingTime = new Timer();
        private Vehicle associatedVehicle;
        private float litresDispensed = 0;

        private Pump(int pumpNo)
        {
            this.pumpNo = pumpNo;
            fuellingTime.Interval = rand.Next(MIN_FUEL_TIME, MAX_FUEL_TIME + 1);
            fuellingTime.AutoReset = false;
            fuellingTime.Elapsed += FuellingTime_Elapsed;
        }

        public static void Initialise()
        {
            int pumpNo = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    pumps[i, j] = new Pump(pumpNo);
                    pumpNo++;
                }
            }
        }

        public bool IsOccupied()
        {
            return this.occupied;
        }
        public int GetPumpNo()
        {
            return this.pumpNo;
        }

        public void IsNowOccupied(Vehicle vehicle)
        {
            associatedVehicle = vehicle;
            this.occupied = true;
            fuellingTime.Start();
        }
        /// <summary>
        /// Calculates how much fuel has been dispensed
        /// Creates a transaction
        /// Updates counters
        /// Clears the pump
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FuellingTime_Elapsed(object sender, ElapsedEventArgs e)
        {
            litresDispensed = (float)(fuellingTime.Interval / 1000) * 1.5f;
            new Transaction(associatedVehicle.GetVehicleType(), litresDispensed, this.GetPumpNo());
            float money = 0;
            switch (associatedVehicle.GetFuelType())
            {
                case "Unleaded":
                    Counters.IncreaseUnleadedLitresDispensed(litresDispensed);
                    //Cost per litre of unleaded = 108.74p https://www.rac.co.uk/drive/advice/fuel-watch/
                    //Accessed 10/05/2020
                    money = litresDispensed * 1.0874f;
                    Counters.IncreaseMoneyMade(money);
                    Counters.IncreaseCommission(money);
                    break;
                case "Diesel":
                    Counters.IncreaseDieselLitresDispensed(litresDispensed);
                    //Cost per litre of diesel = 114.26p https://www.rac.co.uk/drive/advice/fuel-watch/
                    //Accessed 10/05/2020
                    money = litresDispensed * 1.1426f;
                    Counters.IncreaseMoneyMade(money);
                    Counters.IncreaseCommission(money);
                    break;
                case "LPG":
                    Counters.IncreaseLPGLitresDispensed(litresDispensed);
                    //Cost per litre of LPG = 62.01p https://www.rac.co.uk/drive/advice/fuel-watch/
                    //Accessed 10/05/2020
                    money = litresDispensed * 0.6201f;
                    Counters.IncreaseMoneyMade(money);
                    Counters.IncreaseCommission(money);
                    break;
                default:
                    //Fuel type isn't one of the options, should be irrelevant
                    break;
            }
            Counters.IncrementVehiclesServiced();
            this.occupied = false;
            fuellingTime.Interval = rand.Next(MIN_FUEL_TIME, MAX_FUEL_TIME + 1);
        }
    }
}

