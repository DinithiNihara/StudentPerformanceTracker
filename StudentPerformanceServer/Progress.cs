using System;
using System.Text.Json.Serialization;

namespace StudentPerformanceServer
{
    public class Progress
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Percentage { get; set; }
        public int StudySessionId { get; set; }

        public StudySession StudySession { get; set; }
    }
}
