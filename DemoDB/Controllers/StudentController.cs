using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoDL;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoDB.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly OrderMongoDL studentMongoDL = new OrderMongoDL();
        private readonly MalmartMySqlDL malmartMySqlDL = new MalmartMySqlDL();
        [Route("studentmongo")]
        [HttpGet]
        public ActionResult getMongo()
        {
            try
            {
                return Ok(studentMongoDL.Get());
            }
            catch (Exception ex)
            {
                return Ok("Error");
            }
        }
        [Route("studentmongo/{id}")]
        [HttpGet]
        public long getMongoOne(int id)
        {
            return studentMongoDL.GetOne(id);
        }
        [Route("studentmongo")]
        [HttpPut]
        public long UpdateMongo()
        {
            return studentMongoDL.Update();
        }
        [Route("studentmongo/{id}")]
        [HttpPut]
        public long UpdateMongoOne(int id)
        {
            return studentMongoDL.UpdateOne(id);
        }
        [Route("studentmongo/{number}")]
        [HttpDelete]
        public long DeleteMongo(int number)
        {
            return studentMongoDL.Delete(number);
        }
        [Route("studentmongodelete/{id}")]
        [HttpDelete]
        public long DeleteMongoOne(int id)
        {
            return studentMongoDL.DeleteOne(id);
        }

        [Route("student")]
        [HttpGet]
        public ActionResult getSql()
        {
            try
            {
                return Ok(malmartMySqlDL.Get());
            }
            catch (Exception ex)
            {
                return Ok("Error");
            }
        }
        [Route("student/{id}")]
        [HttpGet]
        public ActionResult getSqlOne(int id)
        {
            try
            {
                return Ok(malmartMySqlDL.GetOne(id));
            }
            catch (Exception ex)
            {
                return Ok("Error");
            }
        }
        [Route("student")]
        [HttpPut]
        public long UpdateSql()
        {
            return malmartMySqlDL.Update();
        }
        [Route("student/{id}")]
        [HttpPut]
        public long UpdateSqlOne(int id)
        {
            return malmartMySqlDL.UpdateOne(id);
        }
        [Route("student/{number}")]
        [HttpDelete]
        public long DeleteSql(int number)
        {
            return malmartMySqlDL.Delete(number);
        }
        [Route("studentdelete/{id}")]
        [HttpDelete]
        public long DeleteSqlOne(int id)
        {
            return malmartMySqlDL.DeleteOne(id);
        }
        //[Route("studentmysql")]
        //[HttpGet]
        //public long getMysql()
        //{
        //    return malmartMySqlDL.Get();
        //}
    }
}