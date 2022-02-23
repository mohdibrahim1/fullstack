using StockMarket.Model.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockMarket.Model.Poco
{
    [Table("market.\"Stock\"")]
    public class Stock: BaseModel
    {
        public string Name { get; set; }

        public int Start { get; set; }
        public int End { get; set; }
        
        public int YearHigh { get; set; }
        
        public int YearLow { get; set; }    

    }
}
