using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CS_Interview_Pro.Models
{
    [Serializable()]
    public class Trade
    {
        [XmlElement("TradeId")]
        public string TradeId { get; set; }
        [XmlElement("Type")]
        public TradeType Type { get; set; }
        [XmlElement("TradeDate")]
        public DateTime TradeDate { get; set; }
        [XmlElement("TradeValue")]
        public double TradeValue { get; set; }

        public override string ToString()
        {
            StringBuilder tradeAsString = new StringBuilder();
            tradeAsString.Append("TradeId - ");
            tradeAsString.Append(this.TradeId);
            tradeAsString.Append("   ");
            tradeAsString.Append("Type - ");
            tradeAsString.Append(this.Type.ToString());
            tradeAsString.Append("   ");
            tradeAsString.Append("Trade Date - ");
            tradeAsString.Append(this.TradeDate.ToString("dd/MM/yyyy"));
            tradeAsString.Append("   ");
            tradeAsString.Append("Trade Value - ");
            tradeAsString.Append(this.TradeValue);
            return tradeAsString.ToString();
        }
    }

    public enum TradeType
    {
        CREDIT =0,
        CASH = 1,
        EQUITY = 2
    }
}
