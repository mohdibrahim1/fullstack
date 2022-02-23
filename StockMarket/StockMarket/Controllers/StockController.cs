using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.Interfaces;
using StockMarket.Model.Poco;
using StockMarket.Model.ViewModel;
using System;

namespace StockMarket.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IReadableRepository<StockViewModel> _RepoCommonRead;
        private readonly IWriteableRepository<Stock> _RepoCommonWrite;
        public StockController(IReadableRepository<StockViewModel> RepoCommonRead, IWriteableRepository<Stock> RepoCommonWrite)
        {
            _RepoCommonRead= RepoCommonRead;
            _RepoCommonWrite = RepoCommonWrite; 

        }
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                var data = _RepoCommonRead.Get();
                return new JsonResult(data);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("{id}")]
        public JsonResult GetById(int id)
        {
            try
            {
                var data = _RepoCommonRead.GetById(id);
                return new JsonResult(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public JsonResult Add(Stock item)
        {
            try
            {
                if(item == null)
                {

                    return new JsonResult("invalide data");
                }
                int id = Convert.ToInt32(_RepoCommonWrite.Add(item));
                return new JsonResult(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut]
        public JsonResult Update(Stock item)
        {
            try
            {
                if (item == null)
                {

                    return new JsonResult("invalide data");
                }
                var result = _RepoCommonWrite.Update(item);
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
           
                var result = _RepoCommonWrite.Delete(id);
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
