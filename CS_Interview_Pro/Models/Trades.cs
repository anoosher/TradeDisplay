using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CS_Interview_Pro.Models
{
    [Serializable()]
    [XmlRoot("Trades")]
    public class Trades
    {
        [XmlElement("Trade")]
        public List<Trade> TradeList { get; set; }
    }
}
