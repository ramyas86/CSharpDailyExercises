using System;

namespace LocalGym.Models
{
    public class Session
    {
        public int SessionId { get; set; }
        public int MemberId { get; set; }
        public int TrainerId { get; set; }
        public DateTime SessionDate { get; set; }
        public int Duration { get; set; }

        public Member? Member { get; set; }
        public Trainer? Trainer { get; set; }
    }
}
