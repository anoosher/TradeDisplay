using System;
using System.Collections.Generic;
using System.Text;
using CS_Interview_Pro.Interfaces;
using CS_Interview_Pro.Models;
using System.IO;
using System.Threading.Tasks;

namespace CS_Interview_Pro.Readers
{
    class CsvTradeReader : IDataReader
    {
        public async Task<List<Trade>> ReadMultiple(List<string> fileLocations)
        {
            List<Trade> allTrades = new List<Trade>();

            foreach (var location in fileLocations)
            {
                List<Trade> tradesList = new List<Trade>();

                var allRecords = File.ReadLines(location);
                foreach (var item in allRecords)
                {
                    string[] propList = item.Split(',');
                    Enum.TryParse(propList[1], out TradeType tradeType);

                    tradesList.Add(new Trade()
                    {
                        TradeDate = Convert.ToDateTime(propList[2]),
                        TradeId = propList[0],
                        Type = tradeType,
                        TradeValue = Convert.ToDouble(propList[3])
                    });
                }
                allTrades.AddRange(tradesList);
            }

            return allTrades;
        }
    }
}
