using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StudentPerformanceServer
{
    public class StudySession
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Subject { get; set; }
        public string Type { get; set; }

        public int StudentId { get; set; }

        public ICollection<Break> Breaks { get; set; }

        public ICollection<Progress> Progresses { get; set; }
    }


}
