using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LocalGym.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime JoinDate { get; set; }

        [JsonIgnore]
        public ICollection<Session>? Sessions { get; set; }
    }
}
