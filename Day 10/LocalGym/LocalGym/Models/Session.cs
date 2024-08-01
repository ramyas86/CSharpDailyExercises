using System.Text.Json.Serialization;

namespace LocalGym.Models
{
    public class Session
    {
        public int SessionId { get; set; }
        public int? MemberId { get; set; }
        public int? TrainerId { get; set; }
        public DateTime SessionDate { get; set; }
        public int Duration { get; set; }

        [JsonIgnore]
        public Member? Member { get; set; }

        [JsonIgnore]
        public Trainer? Trainer { get; set; }
    }
}
