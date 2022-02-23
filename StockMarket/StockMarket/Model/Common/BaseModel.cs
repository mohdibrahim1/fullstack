using System.ComponentModel.DataAnnotations;

namespace StockMarket.Model.Common
{
    public class BaseModel
    {
        [Key]
        public int id { get; set; }
    }
}
