using System;
using System.Collections.Generic;
using CS_Interview_Pro.Interfaces;
using CS_Interview_Pro.Models;
using CS_Interview_Pro.Readers;
using System.IO;
using System.Threading.Tasks;

namespace CS_Interview_Pro
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataReader xmlReader = new XmlTradeReader();
            IDataReader csvReader = new CsvTradeReader();

            List<string> xmlFileLocations = new List<string>();
            xmlFileLocations.Add(@"C:\Users\AnushaA\source\repos\CS_Interview\CS_Interview_Pro\DataSource\MockTradeData.xml");

            List<string> csvFileLocations = new List<string>();
            csvFileLocations.Add(@"C:\Users\AnushaA\source\repos\CS_Interview\CS_Interview_Pro\DataSource\TradeMockData.txt");

            Task<List<Trade>> tXml = xmlReader.ReadMultiple(xmlFileLocations);
            Task<List<Trade>> tCsv = csvReader.ReadMultiple(csvFileLocations);

            Task.WaitAll(tXml, tCsv);

            var allTrades = tXml.Result;
            allTrades.AddRange(tCsv.Result);

            Console.WriteLine("TRADE LIST");
            Console.WriteLine("*************************************************************************");

            foreach (Trade tradeItem in allTrades)
            {
                Console.WriteLine("Trade : " + tradeItem.ToString());
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}
 