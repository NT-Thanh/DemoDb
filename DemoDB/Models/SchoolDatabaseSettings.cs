﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoDB.Models
{
    public class SchoolDatabaseSettings : ISchoolDatabaseSettings
    {
        public string StudentsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ISchoolDatabaseSettings
    {
        string StudentsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
