namespace GL.Servers.CoC.Logic.Battles
{
    using System.Collections.Generic;

    using GL.Servers.CoC.Core.Network;

    using GL.Servers.CoC.Logic.Interfaces;

    using GL.Servers.CoC.Packets;
    using GL.Servers.CoC.Packets.Messages.Server;

    public class PvPBattle : IBattle
    {
        /// <summary>
        /// The base.
        /// </summary>
        public Objects Level            { get; set; }

        /// <summary>
        /// The attacker.
        /// </summary>
        public Player Attacker          { get; set; }

        /// <summary>
        /// The defender.
        /// </summary>
        public Player Defender          { get; set; }

        /// <summary>
        /// The last tick of client.
        /// </summary>
        public int EndTick              { get; set; }

        /// <summary>
        /// End timestamp.
        /// </summary>
        public int Timestamp            { get; set; }

        /// <summary>
        /// List of command.
        /// </summary>
        public List<Command> Commands   { get; set; }

        /// <summary>
        /// Initializes new instance of the <see cref="PvPBattle"/>
        /// </summary>
        /// <param name="Level">The base.</param>
        /// <param name="Attacker">The attacker.</param>
        /// <param name="Defender">The defender.</param>
        public PvPBattle(Objects Level, Player Attacker, Player Defender)
        {
            this.Level    = Level;

            this.Attacker = Attacker.Copy();
            this.Defender = Defender;
        }

        /// <summary>
        /// Refresh battle.
        /// </summary>
        /// <param name="Tick">The tick.</param>
        public void Refresh(float Tick)
        {
            if ((int)(Tick * 62.5f + 0.5f) > EndTick)
            {
                this.EndTick = (int)(Tick * 62.5f + 0.5f);
            }
            else
            {
                new Server_Error(this.Attacker.Device, $"Execute command failed! Command should have been executed already. (server_tick={this.EndTick} client_tick={(int)(Tick * 62.5f + 0.5f)})").Send();
            }
        }

        /// <summary>
        /// Processes the command.
        /// </summary>
        /// <param name="Command">The command.</param>
        public void Process(Command Command)
        {
            if (Command.Identifier >= 700 && Command.Identifier < 800)
            {
                Command.Process();
            }
            else
            {
                new Server_Error(this.Attacker.Device, "Execute command failed! Command is only allowed in home state.").Send();
            }
        }
    }
}
