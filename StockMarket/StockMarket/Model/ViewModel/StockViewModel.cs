using StockMarket.Model.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockMarket.Model.ViewModel
{
    [Table("market.\"Stock\"")]
    public class StockViewModel: BaseModel
    {
        public string Name { get; set; }

        public int Start { get; set; }
        public int End { get; set; }

        public int YearHigh { get; set; }

        public int YearLow { get; set; }
    }
}
