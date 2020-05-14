using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOD003212_Assignment2
{
    static class Display
    {
        private static Queue<Vehicle> vehicles = new Queue<Vehicle>();
        public static void UpdateDisplay()
        {
            try
            {
                vehicles = Vehicle.GetVehicles();
                Console.Clear();
                UpdateQueueDisplay();
                UpdatePumpDisplay();
                UpdateCounterDisplay();
            }
            //This try-catch should be unnecessary - it's a precaution against the display taking too long to update
            //If it's left running for a long time, the list of transactions could take a long time to output
            //So the program might call this method while it's still running
            //I haven't experienced this problem
            catch (InvalidOperationException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }
        private static void UpdateQueueDisplay()
        {
            foreach (Vehicle vehicle in vehicles)
            {
                Console.Write("||  {0}   {1} ", vehicle.GetVehicleID(), vehicle.GetVehicleType());
            }
            Console.WriteLine();
        }
        private static void UpdatePumpDisplay()
        {
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Lane {0}:", i + 1);
                for (int j = 0; j < 3; j++)
                {
                    if (Pump.pumps[i, j].IsOccupied())
                    {
                        Console.Write(" <BUSY>");
                    }
                    else
                    {
                        Console.Write(" <FREE>");
                    }
                }
                Console.Write("\n");
            }
            Console.WriteLine();
        }
        private static void UpdateCounterDisplay()
        {
            Console.WriteLine();
            //counter display stuff
            Console.WriteLine("Litres dispensed (unleaded): {0}", Counters.GetUnleadedLitresDispensed());
            Console.WriteLine("Litres dispensed (diesel): {0}", Counters.GetDieselLitresDispensed());
            Console.WriteLine("Litres dispensed (LPG): {0}", Counters.GetLPGLitresDispensed());
            decimal moneyMade = Math.Round((decimal)Counters.GetMoneyMade(), 2);
            Console.WriteLine("Money made: £{0}", moneyMade);
            decimal commission = Math.Round((decimal)Counters.GetCommission(), 2);
            Console.WriteLine("Commission earned: £{0}", commission);
            Console.WriteLine("Vehicles that left early: {0}", Counters.GetVehiclesLeft());
            Console.WriteLine("Vehicles serviced: {0}", Counters.GetVehiclesServiced());
            Console.WriteLine("Transactions: ");
            foreach (Transaction transaction in Counters.GetTransactions())
            {
                Console.WriteLine(" -Vehicle type: {0}  Litres: {1}  Pump number: {2}", transaction.GetVehicleType(), transaction.GetNoOfLitres(), transaction.GetPumpNo());
            }
        }
    }
}
