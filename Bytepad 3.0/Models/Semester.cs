﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bytepad_3._0.Models
{
    public class Semester : ISemester
    {
        public int Id { get; set; }
        public string SemesterType { get; set; }

        public List<Semester> GetAllSemesters()
        {
            List<Semester> dataSemester = new List<Semester>();
            dataSemester.Add(new Semester { Id = 1, SemesterType = "Even" });
            dataSemester.Add(new Semester { Id = 2, SemesterType = "Odd" });
            return dataSemester;
        }

        public string GetSemesterTypeById(string id)
        {
            if (id == "1")
            {
                return "Even";
            }
            else
            {
                return "Odd";
            }
        }
    }
}