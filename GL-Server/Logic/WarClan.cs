using GL.Servers.CoC.Logic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

﻿namespace GL.Servers.CoC.Logic
{
    public class WarClan : BadRequest
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("badgeUrls")]
        public Dictionary<string, string> BadgeUrls { get; set; }
        
        [JsonProperty("clanLevel")]
        public int ClanLevel { get; set; }

        [JsonProperty("attacks")]
        public int Attacks { get; set; }

        [JsonProperty("stars")]
        public int Stars { get; set; }

        [JsonProperty("destructionPercentage")]
        public decimal DestructionPercentage { get; set; }

        [JsonProperty("members")]
        public List<WarMember> Members { get; set; }
    }
}
