namespace GL.Servers.CoC.Packets
{
    using System;
    using System.Collections.Generic;

    using GL.Servers.CoC.Packets.Commands.Client;
    using GL.Servers.CoC.Packets.Commands.Server;
    using GL.Servers.CoC.Packets.Messages.Client;

    using DonateClanUnit = GL.Servers.CoC.Packets.Commands.Server.DonateClanUnit;
    using JoinClan = GL.Servers.CoC.Packets.Commands.Server.JoinClan;
    using LeaveClan = GL.Servers.CoC.Packets.Commands.Server.LeaveClan;

    internal static class Factory
    {
        /// <summary>
        /// The delimiter used to detect if x string is a call-command.
        /// </summary>
        internal const char Delimiter = '/';

        internal static readonly Dictionary<ushort, Type> Messages = new Dictionary<ushort, Type>();
        internal static readonly Dictionary<ushort, Type> Commands = new Dictionary<ushort, Type>();
        internal static readonly Dictionary<string, Type> Debugs = new Dictionary<string, Type>();

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        internal static void Initialize()
        {
            Factory.LoadMessages();
            Factory.LoadCommands();
            Factory.LoadDebugs();
        }

        /// <summary>
        /// Loads the game messages.
        /// </summary>
        private static void LoadMessages()
        {
            Factory.Messages.Add(10100, typeof(PreAuthentification));
            Factory.Messages.Add(10101, typeof(Authentification));

            Factory.Messages.Add(10108, typeof(Keep_Alive));
            Factory.Messages.Add(10113, typeof(Get_Device_Token));

            Factory.Messages.Add(10212, typeof(ChangePlayerName));

            Factory.Messages.Add(10905, typeof(AskInboxData));

            Factory.Messages.Add(14101, typeof(GoHome));
            Factory.Messages.Add(14102, typeof(Execute_Commands));

            Factory.Messages.Add(14134, typeof(AttackNpc));

            Factory.Messages.Add(14301, typeof(CreateClan));
            Factory.Messages.Add(14302, typeof(AskClanData));
            Factory.Messages.Add(14303, typeof(AskJoinableClans));

            Factory.Messages.Add(14305, typeof(JoinClan));
            Factory.Messages.Add(14306, typeof(ChangeClanMemberRole));
            Factory.Messages.Add(14307, typeof(KickClanMember));
            Factory.Messages.Add(14308, typeof(LeaveClan));

            Factory.Messages.Add(14310, typeof(DonateClanUnit));

            Factory.Messages.Add(14315, typeof(ChatToClanStream));
            Factory.Messages.Add(14316, typeof(ChangeClanSettings));
            Factory.Messages.Add(14317, typeof(RequestJoinClan));

            Factory.Messages.Add(14321, typeof(RespondClanJoinRequest));

            Factory.Messages.Add(14325, typeof(AskPlayerProfile));

            Factory.Messages.Add(14715, typeof(SendGlobalChatLine));

            Factory.Messages.Add(16000, typeof(DeviceLinkCodeRequest));
            Factory.Messages.Add(16001, typeof(DeviceLinkMenuClosed));
            Factory.Messages.Add(16002, typeof(DeviceLinkEnterCode));
            Factory.Messages.Add(16003, typeof(DeviceLinkConfirmYes));
        }

        /// <summary>
        /// Loads the game commands.
        /// </summary>
        private static void LoadCommands()
        {
            Factory.Commands.Add(1, typeof(JoinClan));
            Factory.Commands.Add(2, typeof(LeaveClan));
            Factory.Commands.Add(3, typeof(ChangeName));
            Factory.Commands.Add(4, typeof(DonateClanUnit));
            Factory.Commands.Add(5, typeof(ClanUnitReceived));
            Factory.Commands.Add(6, typeof(ClanSettingsChanged));
            Factory.Commands.Add(7, typeof(GemsAdded));
            Factory.Commands.Add(8, typeof(ChangeClanRole));

            Factory.Commands.Add(500, typeof(BuyBuilding));
            Factory.Commands.Add(501, typeof(MoveGameObject));
            Factory.Commands.Add(502, typeof(UpgradeGameObject));
            Factory.Commands.Add(503, typeof(SellGameObjects));
            Factory.Commands.Add(504, typeof(SpeedUpConstruction));
            Factory.Commands.Add(505, typeof(CancelConstruction));
            Factory.Commands.Add(506, typeof(CollectResources));
            Factory.Commands.Add(507, typeof(ClearObstacle));
            Factory.Commands.Add(508, typeof(TrainUnit));
            Factory.Commands.Add(509, typeof(CancelUnitProduction));

            Factory.Commands.Add(510, typeof(BuyTrap));
            Factory.Commands.Add(511, typeof(RequestClanUnits));
            Factory.Commands.Add(512, typeof(BuyDeco));
            Factory.Commands.Add(513, typeof(SpeedUpTraining));
            Factory.Commands.Add(514, typeof(SpeedUpClearing));
            Factory.Commands.Add(515, typeof(CancelUpgradeUnit));
            Factory.Commands.Add(516, typeof(UpgradeUnit));
            Factory.Commands.Add(517, typeof(SpeedUpUpgradeUnit));
            Factory.Commands.Add(518, typeof(BuyResources));
            Factory.Commands.Add(519, typeof(MissionProgress));

            Factory.Commands.Add(520, typeof(UnlockBuilding));
            Factory.Commands.Add(521, typeof(FreeWorker));
            Factory.Commands.Add(522, typeof(BuyShield));
            Factory.Commands.Add(523, typeof(ClaimAchievement));
            Factory.Commands.Add(524, typeof(ToggleAttackMode));
            Factory.Commands.Add(525, typeof(LoadTurret));
            Factory.Commands.Add(526, typeof(BoostBuilding));
            Factory.Commands.Add(527, typeof(UpgradeHero));
            Factory.Commands.Add(528, typeof(SpeedUpHeroUpgrade));
            Factory.Commands.Add(529, typeof(ToggleHeroSleep));

            Factory.Commands.Add(530, typeof(SpeedUpHeroHealth));
            Factory.Commands.Add(531, typeof(CancelHeroUpgrade));
            Factory.Commands.Add(532, typeof(NewShopItemsSeen));
            Factory.Commands.Add(533, typeof(MoveMultipleBuildings));
            Factory.Commands.Add(534, typeof(RemoveProtection));
            Factory.Commands.Add(535, typeof(ChangeLeague));
            Factory.Commands.Add(536, typeof(BuyFreeBuilding));
            Factory.Commands.Add(537, typeof(SendClanMail));
            Factory.Commands.Add(538, typeof(LeagueNotificationSeen));
            Factory.Commands.Add(539, typeof(NewsSeen));

            Factory.Commands.Add(540, typeof(TroopRequestMessage));
            Factory.Commands.Add(541, typeof(SpeedUpTroopRequest));
            Factory.Commands.Add(542, typeof(ShareReplay));
            Factory.Commands.Add(543, typeof(ElderKick));
            Factory.Commands.Add(544, typeof(EditModeShown));
            Factory.Commands.Add(545, typeof(Replay));

            Factory.Commands.Add(549, typeof(UpgradeMultipleBuildings));

            Factory.Commands.Add(573, typeof(ShieldCostSeen));

            Factory.Commands.Add(700, typeof(PlaceAttacker));
            Factory.Commands.Add(701, typeof(PlaceClanPortal));
            Factory.Commands.Add(702, typeof(EndAttackPreparation));
            Factory.Commands.Add(703, typeof(EndCombat));
            Factory.Commands.Add(704, typeof(CastSpell));
            Factory.Commands.Add(705, typeof(PlaceHero));

            Factory.Commands.Add(800, typeof(Matchmaking));
            Factory.Commands.Add(801, typeof(CommandFailed));

            Factory.Commands.Add(1000, typeof(Debug));
        }

        /// <summary>
        /// Loads the debug commands.
        /// </summary>
        private static void LoadDebugs()
        {
            
        }
    }
}
