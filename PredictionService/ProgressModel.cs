using System;

namespace PredictionService
{
    public class ProgressModel
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public int percentage { get; set; }
        public int StudySessionId { get; set; }
        public StudySessionModel session { get; set; }
    }
}
