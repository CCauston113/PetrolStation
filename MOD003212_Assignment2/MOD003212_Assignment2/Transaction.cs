using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MOD003212_Assignment2
{
    class Transaction
    {
        private static string fileName = "transactions.txt";
        private string vehicleType = "";

        private float noOfLitres = 0;

        private int pumpNo = 0;

        /// <summary>
        /// Creates a new transaction and appends it to the text file
        /// Also adds it to the list of transactions in Counters
        /// </summary>
        /// <param name="vehicleType">The vehicleType of the vehicle that is leaving</param>
        /// <param name="noOfLitres">The no of litres that were dispensed</param>
        /// <param name="pumpNo">The pump no that was used</param>
        public Transaction(string vehicleType, float noOfLitres, int pumpNo)
        {
            this.vehicleType = vehicleType;
            this.noOfLitres = noOfLitres;
            this.pumpNo = pumpNo;
            Counters.AddTransaction(this);
            //var transaction = "Vehicle type: " + this.vehicleType + "    Litres dispensed: " + this.noOfLitres + "    Pump number: " + this.pumpNo;
            //using (StreamWriter sw = File.AppendText(fileName))
            //{
            //    sw.WriteLine(transaction);
            //}
        }

        public string GetVehicleType()
        {
            return this.vehicleType;
        }
        public float GetNoOfLitres()
        {
            return this.noOfLitres;
        }
        public int GetPumpNo()
        {
            return this.pumpNo;
        }
    }
}
