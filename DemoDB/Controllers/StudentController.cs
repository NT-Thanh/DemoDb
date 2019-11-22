using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoDB.Services;
using DemoDL;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoDB.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentMongoDL studentMongoDL = new StudentMongoDL();
        [Route("studentmongo")]
        [HttpGet]
        public List<Student> getMongo()
        {
            return studentMongoDL.Get();
        }
    }
}