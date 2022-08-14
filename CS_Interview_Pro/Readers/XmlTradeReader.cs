using System;
using System.Collections.Generic;
using CS_Interview_Pro.Interfaces;
using CS_Interview_Pro.Models;
using System.Xml;
using System.IO;
using System.Threading.Tasks;

namespace CS_Interview_Pro.Readers
{
    public class XmlTradeReader : IDataReader
    {
        public async Task<List<Trade>> ReadMultiple(List<string> fileLocations)
        {

            List<Trade> allTrades = new List<Trade>();

            foreach (var location in fileLocations)
            {
                List<Trade> trades = new List<Trade>();

                XmlDocument doc = new XmlDocument();
                doc.Load(location);

                foreach (var item in doc.GetElementsByTagName("Trade"))
                {
                    Enum.TryParse(((System.Xml.XmlNode)item).ChildNodes[1].InnerText.Trim(), out TradeType tradeType);

                    trades.Add(new Trade()
                    {
                        TradeDate = Convert.ToDateTime(((System.Xml.XmlNode)item).ChildNodes[2].InnerText.Trim()),
                        TradeId = ((System.Xml.XmlNode)item).ChildNodes[0].InnerText.Trim(),
                        TradeValue = Convert.ToDouble(((System.Xml.XmlNode)item).ChildNodes[3].InnerText.Trim()),
                        Type = tradeType
                    });
                }

                allTrades.AddRange(trades);
            }

            return allTrades;

        }
    }
}
