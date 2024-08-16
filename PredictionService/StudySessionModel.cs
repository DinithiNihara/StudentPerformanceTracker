﻿using System.Collections.Generic;
using System;

namespace PredictionService
{
    public class StudySessionModel
    {
        public int Id { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public TimeSpan startTime { get; set; }
        public TimeSpan endTime { get; set; }
        public String subject { get; set; }
        public String type { get; set; }
        public List<ProgressModel> progresses { get; set; }
        public List<BreakModel> breaks { get; set; }

    }
}
