using System;
using System.Text.Json.Serialization;

namespace StudentPerformanceServer
{
    public class Break
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int StudySessionId { get; set; }

        public StudySession StudySession { get; set; }
    }
}
