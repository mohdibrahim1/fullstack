using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using StockMarket.Helper;
using StockMarket.Interfaces;
using StockMarket.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace StockMarket.Repository.stock
{
    public class StockQueryRepository: IReadableRepository<StockViewModel>
    {
        private readonly DBConnection _dbcon;
        public StockQueryRepository(IConfiguration configuration)
        {
            _dbcon = new DBConnection(configuration);

        }

        public List<StockViewModel> Get()
        {
            try
            {
                using (IDbConnection con = _dbcon.Connection)
                    return con.GetAll<StockViewModel>().ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public StockViewModel GetById(int id)
        {
            try
            {
                using (IDbConnection con = _dbcon.Connection)
                    return con.Get<StockViewModel>(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
