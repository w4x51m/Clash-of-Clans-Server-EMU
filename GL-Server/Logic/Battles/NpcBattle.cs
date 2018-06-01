namespace GL.Servers.CoC.Logic.Battles
{
    using System.Collections.Generic;

    using GL.Servers.CoC.Core.Network;

    using GL.Servers.CoC.Logic.Interfaces;

    using GL.Servers.CoC.Packets;
    using GL.Servers.CoC.Packets.Messages.Server;

    public class NpcBattle : IBattle
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
        /// Initializes new instance of the <see cref="NpcBattle"/>
        /// </summary>
        /// <param name="Level">The base.</param>
        /// <param name="Attacker">The attacker.</param>
        /// <param name="Defender">The defender.</param>
        public NpcBattle(Objects Level, Player Attacker)
        {
            this.Level    = Level;

            this.Attacker = Attacker;
            this.Defender = null;
        }

        /// <summary>
        /// Refresh battle.
        /// </summary>
        /// <param name="Tick">The tick.</param>
        public void Refresh(float Tick)
        {
            if (Tick * 62.5f + 0.5f > EndTick)
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
            if (Command.Identifier >= 600 && Command.Identifier < 700)
            {

            }
            else
            {
                new Server_Error(this.Attacker.Device, "Execute command failed! Command is only allowed in home state.").Send();
            }
        }
    }
}
