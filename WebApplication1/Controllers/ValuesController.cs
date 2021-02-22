﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ValuesController : ApiController
    {


        string status = "false";
        DAL dal = new DAL();

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }





        [Route("api/Values/getsampleData")]
        [HttpGet]
        public DataTable GetAllEmployeeData(string Username)
        {
            DataTable table = new DataTable { TableName = "MyTableName" };
            table = dal.GetEmployeeData(Username);
            return table;
        }







        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
