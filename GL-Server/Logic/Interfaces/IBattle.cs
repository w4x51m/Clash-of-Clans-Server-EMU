namespace GL.Servers.CoC.Logic.Interfaces
{
    using GL.Servers.CoC.Packets;

    using System.Collections.Generic;

    public interface IBattle
    {
        Objects Level { get; set; }

        Player Attacker { get; set; }
        Player Defender { get; set; }

        int EndTick { get; set; }
        int Timestamp { get; set; }

        List<Command> Commands { get; set; }

        void Refresh(float Tick);
        void Process(Command Comamnd);
    }
}
