﻿using System.Collections.Generic;

namespace StudentPerformanceServer
{
    public class Student
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Subject> Subjects { get; set; } 
    }

}
