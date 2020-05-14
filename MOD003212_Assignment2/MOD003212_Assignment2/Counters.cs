using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOD003212_Assignment2
{
    static class Counters
    {
        /// <summary>
        /// Counter1
        /// </summary>
        private static float unleadedLitresDispensed = 0;
        /// <summary>
        /// Update counter of litres dispensed
        /// </summary>
        /// <param name="litres">The no of litres in this transaction</param>
        public static void IncreaseUnleadedLitresDispensed(float litres)
        {
            unleadedLitresDispensed += litres;
        }
        /// <summary>
        /// Gets the no of litres dispensed since starting the application
        /// </summary>
        /// <returns>The no of litres dispensed in runtime</returns>
        public static float GetUnleadedLitresDispensed()
        {
            return unleadedLitresDispensed;
        }

        private static float dieselLitresDispensed = 0;
        public static void IncreaseDieselLitresDispensed(float litres)
        {
            dieselLitresDispensed += litres;
        }
        public static float GetDieselLitresDispensed()
        {
            return dieselLitresDispensed;
        }

        private static float LPGLitresDispensed = 0;
        public static void IncreaseLPGLitresDispensed(float litres)
        {
            LPGLitresDispensed += litres;
        }
        public static float GetLPGLitresDispensed()
        {
            return LPGLitresDispensed;
        }
        /// <summary>
        /// Counter 2
        /// </summary>
        private static float moneyMade = 0;
        /// <summary>
        /// Update counter of money made
        /// </summary>
        /// <param name="money">The money made from this transaction</param>
        public static void IncreaseMoneyMade(float money)
        {
            moneyMade += money;
        }
        /// <summary>
        /// Gets the money made since starting the application
        /// </summary>
        /// <returns>The money made in runtime</returns>
        public static float GetMoneyMade()
        {
            return (float)Math.Round(moneyMade, 2);
        }

        /// <summary>
        /// Counter 3
        /// </summary>
        private static float commission = 0;
        /// <summary>
        /// Update counter of commission
        /// </summary>
        /// <param name="money">The money made from this transaction</param>
        public static void IncreaseCommission(float money)
        {
            commission += (0.01f * money);
        }
        /// <summary>
        /// Gets the total commission earned since startup
        /// </summary>
        /// <returns>The total commission earned in runtime</returns>
        public static float GetCommission()
        {
            return (float)Math.Round(commission, 2);
        }

        /// <summary>
        /// Counter 4
        /// </summary>
        private static int vehiclesServiced = 0;
        /// <summary>
        /// Increment counter of vehicles serviced
        /// </summary>
        public static void IncrementVehiclesServiced()
        {
            vehiclesServiced++;
        }
        /// <summary>
        /// Gets the number of vehicles serviced since startup
        /// </summary>
        /// <returns>The no of vehicles serviced in runtime</returns>
        public static int GetVehiclesServiced()
        {
            return vehiclesServiced;
        }

        /// <summary>
        /// Counter 5
        /// The number of vehicles that have left due to not being serviced in time
        /// </summary>
        private static int vehiclesLeft = 0;
        /// <summary>
        /// Increment the number of vehicles that have left early since startup
        /// </summary>
        public static void IncrementVehiclesLeft()
        {
            vehiclesLeft++;
        }
        /// <summary>
        /// Gets the number of vehicles that have left early since startup
        /// </summary>
        /// <returns>The no of vehicles that have left early in runtime</returns>
        public static int GetVehiclesLeft()
        {
            return vehiclesLeft;
        }

        /// <summary>
        /// Counter 6
        /// </summary>
        private static List<Transaction> transactions = new List<Transaction>();
        /// <summary>
        /// Add a transaction to the list
        /// </summary>
        /// <param name="transaction">A new transaction</param>
        public static void AddTransaction(Transaction transaction)
        {
            transactions.Add(transaction);
        }
        /// <summary>
        /// Gets the current list of transactions
        /// </summary>
        /// <returns>The list of transactions</returns>
        public static List<Transaction> GetTransactions()
        {
            return transactions;
        }
    }
}
