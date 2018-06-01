namespace GL.Servers.CoC.Logic
{
    using System;
    using System.Collections.Generic;
    
    using GL.Servers.CoC.Extensions.List;
    using GL.Servers.CoC.Logic.Slots;
    using GL.Servers.CoC.Logic.Slots.Items;

    using GL.Servers.CoC.Core.Network;
    using GL.Servers.CoC.Extensions.Game;
    using GL.Servers.CoC.Packets.Messages.Server;

    using Newtonsoft.Json;

    public class Objects
    {
        [JsonIgnore]
        internal Player Player;

        [JsonIgnore]
        internal string NPCVillage;

        [JsonProperty("exp_ver")]        internal const int ExpVersion = 1;
        
        [JsonProperty("wave_num")]       internal int? WaveNum;


        [JsonProperty("android_client")] internal bool? AndroidClient;
        [JsonProperty("direct")]         internal bool? Direct;
        [JsonProperty("direct2")]        internal bool? Direct2;

        [JsonProperty("shield")]         internal float Shield         = 43200;
        [JsonProperty("guard")]          internal float Guard          = 1800;
        [JsonProperty("next_break")]     internal float NextBreak      = 14400;

        [JsonProperty("buildings")]      internal Buildings Buildings;
        [JsonProperty("obstacles")]      internal Obstacles Obstacles;
        [JsonProperty("traps")]          internal Traps Traps;
        [JsonProperty("decos")]          internal Decos Decos;

        [JsonProperty("vobjs")]          internal VillageObjects VillageObjects; 

        [JsonProperty("buildings2")]     internal Buildings Buildings2;
        [JsonProperty("obstacles2")]     internal Obstacles Obstacles2;
        [JsonProperty("traps2")]         internal Traps Traps2;
        [JsonProperty("decos2")]         internal Decos Decos2;

        [JsonProperty("respawnVars")]    internal RespawnVariables RespawnVariables;

        [JsonProperty("troop_req_msg")]  internal string TroopRequestMessage;
        [JsonProperty("war_req_msg")]    internal string WarRequestMessage;

        /*[JsonProperty("army_names")] */    internal string[] ArmyNames = {"","","",""};

        internal Collider Collider;
        internal Collider Collider2;

        [JsonProperty("es")]             internal DateTime EndSession = DateTime.UtcNow;

        /// <summary>
        /// Initializes a new instance of the <see cref="Objects"/> class.
        /// </summary>
        internal Objects()
        {
            this.Buildings  = new Buildings(this);
            this.Buildings2 = new Buildings(this, true);

            this.Obstacles  = new Obstacles(this);
            this.Obstacles2 = new Obstacles(this, true);

            this.Traps      = new Traps(this);
            this.Traps2     = new Traps(this, true);

            this.Decos      = new Decos(this);
            this.Decos2     = new Decos(this, true);

            this.VillageObjects = new VillageObjects(this);

            this.Collider   = new Collider(this);
            this.Collider2  = new Collider(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Objects"/> class.
        /// </summary>
        /// <param name="Player">The player.</param>
        internal Objects(Player Player) : this()
        {
            this.Player = Player;
        }

        internal Objects(Player Player, string NPCVillage = "") : this()
        {
            this.Player = Player;
            this.NPCVillage = NPCVillage;
        }

        internal byte[] ToBytes(bool NPC = false)
        {
            var Packet = new List<byte>();

            if (NPC)
                Packet.AddInt(0); // Timestamp for NPC

            Packet.AddInt(this.Player.HighID);
            Packet.AddInt(this.Player.LowID);

            Packet.AddInt((int)this.Shield);
            Packet.AddInt((int)this.Guard);
            Packet.AddInt((int)(this.Shield + this.NextBreak));

            if (NPC)
                Packet.AddCompressed(this.NPCVillage);
            else
                Packet.AddCompressed(this.Serialize());

            Packet.AddCompressed("{\"event\":[]}");
            Packet.AddCompressed("{\"Village2\":{\"TownHallMaxLevel\":5}}");

            return Packet.ToArray();
        }

        /// <summary>
        /// Synchronizes this instance and <see cref="Player"/>.
        /// </summary>
        internal void Synchronize()
        {
            this.Buildings.Synchronize();
            this.Obstacles.Synchronize();
            this.Traps.Synchronize();
            this.Decos.Synchronize();
            
            this.Buildings2.Synchronize();
            this.Obstacles2.Synchronize();
            this.Traps2.Synchronize();
            this.Decos2.Synchronize();
            
            this.VillageObjects.Synchronize();

            this.Player.Missions.Synchronize();
            this.Player.Progress.Synchronize();

            this.Shield = (int) this.Shield;
            this.Guard  = (int) this.Guard;
        }

        /// <summary>
        /// Refreshes the specified tick.
        /// </summary>
        /// <param name="Tick">The tick.</param>
        internal void Refresh(float Tick)
        {
            this.EndSession = DateTime.UtcNow;

            this.Buildings.Refresh(Tick);
            this.Obstacles.Refresh(Tick);

            this.Traps.Refresh(Tick);
            this.Decos.Refresh(Tick);

            this.Buildings2.Refresh(Tick);
            this.Obstacles2.Refresh(Tick);
            this.Traps2.Refresh(Tick);
            this.Decos2.Refresh(Tick);

            this.VillageObjects.Refresh(Tick);

            this.Shield -= Tick;

            if (this.Shield <= 0f)
            {
                this.Guard += this.Shield;

                if (this.Guard <= 0f)
                {
                    this.NextBreak += this.Guard;

                    if (this.NextBreak <= 0f)
                    {
                        this.NextBreak = 0;
                    }
                    else if (this.NextBreak <= 300f)
                    {
                        new PersonalBreakStarted(this.Player.Device).Send();
                    }

                    this.Guard = 0;
                }
                else this.NextBreak = 14400;

                this.Shield = 0;
            }
        }
    }
}
