namespace GL.Servers.CoC.Logic.Slots.Items
{
    using Newtonsoft.Json;

    internal class RespawnVariables
    {
        [JsonProperty("secondsFromLastRespawn")] internal int SecondsFromLastRespawn;
        [JsonProperty("respawnSeed")]            internal int RespawnSeed;
        [JsonProperty("obstacleClearCounter")]   internal int ObstacleClearCounter;
    }
}
