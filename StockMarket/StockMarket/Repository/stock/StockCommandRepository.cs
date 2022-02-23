using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using StockMarket.Helper;
using StockMarket.Interfaces;
using StockMarket.Model.Poco;
using System;
using System.Data;

namespace StockMarket.Repository.stock
{
    public class StockCommandRepository: IWriteableRepository<Stock>
    {
        private readonly DBConnection _dbcon;
        public StockCommandRepository(IConfiguration configuration)
        {
            _dbcon = new DBConnection(configuration);
        }

        public long Add(Stock item)
        {
            try
            {
                using(IDbConnection con = _dbcon.Connection)
                {
                    long id = con.Insert(item);
                    return id;
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (IDbConnection con = _dbcon.Connection)
                {
                    bool result = con.Delete(new Stock { id=id});
                    return result;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Stock item)
        {
            try
            {
                using (IDbConnection con = _dbcon.Connection)
                {
                    bool result = con.Update(item);
                    return result;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
