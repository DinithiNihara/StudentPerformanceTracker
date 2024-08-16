using System;

namespace StudySessionManagement
{
    public class BreakModel
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public TimeSpan startTime { get; set; }
        public TimeSpan endTime { get; set; }
        public int StudySessionId { get; set; }
        public StudySessionModel session { get; set; }
    }
}
