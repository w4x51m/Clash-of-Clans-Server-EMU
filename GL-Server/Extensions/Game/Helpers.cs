using GL.Servers.CoC.Files;
using GL.Servers.CoC.Files.CSV_Logic;
using GL.Servers.CoC.Logic.Enums;

namespace GL.Servers.CoC.Extensions.Game
{
    internal class Helpers
    {
        internal static int[] ResourceGemsCost;
        internal static int[] SpeedUpGemsCost;


        /// <summary>
        /// Initializes a new instance of the <see cref="Helpers"/> class.
        /// </summary>
        internal Helpers()
        {
            Helpers.ResourceGemsCost = new int[] { (CSV.Tables.Get(Gamefile.Globals).GetData("RESOURCE_DIAMOND_COST_100") as Globals).NumberValue,
                (CSV.Tables.Get(Gamefile.Globals).GetData("RESOURCE_DIAMOND_COST_1000") as Globals).NumberValue,
                (CSV.Tables.Get(Gamefile.Globals).GetData("RESOURCE_DIAMOND_COST_10000") as Globals).NumberValue,
                (CSV.Tables.Get(Gamefile.Globals).GetData("RESOURCE_DIAMOND_COST_100000") as Globals).NumberValue,
                (CSV.Tables.Get(Gamefile.Globals).GetData("RESOURCE_DIAMOND_COST_1000000") as Globals).NumberValue,
                (CSV.Tables.Get(Gamefile.Globals).GetData("RESOURCE_DIAMOND_COST_10000000") as Globals).NumberValue,

                (CSV.Tables.Get(Gamefile.Globals).GetData("VILLAGE2_RESOURCE_DIAMOND_COST_100") as Globals).NumberValue,
                (CSV.Tables.Get(Gamefile.Globals).GetData("VILLAGE2_RESOURCE_DIAMOND_COST_1000") as Globals).NumberValue,
                (CSV.Tables.Get(Gamefile.Globals).GetData("VILLAGE2_RESOURCE_DIAMOND_COST_10000") as Globals).NumberValue,
                (CSV.Tables.Get(Gamefile.Globals).GetData("VILLAGE2_RESOURCE_DIAMOND_COST_100000") as Globals).NumberValue,
                (CSV.Tables.Get(Gamefile.Globals).GetData("VILLAGE2_RESOURCE_DIAMOND_COST_1000000") as Globals).NumberValue,
                (CSV.Tables.Get(Gamefile.Globals).GetData("VILLAGE2_RESOURCE_DIAMOND_COST_10000000") as Globals).NumberValue };

            Helpers.SpeedUpGemsCost = new int[] { (CSV.Tables.Get(Gamefile.Globals).GetData("SPEED_UP_DIAMOND_COST_1_MIN") as Globals).NumberValue,
                (CSV.Tables.Get(Gamefile.Globals).GetData("SPEED_UP_DIAMOND_COST_1_HOUR") as Globals).NumberValue,
                (CSV.Tables.Get(Gamefile.Globals).GetData("SPEED_UP_DIAMOND_COST_24_HOURS") as Globals).NumberValue,
                (CSV.Tables.Get(Gamefile.Globals).GetData("SPEED_UP_DIAMOND_COST_1_WEEK") as Globals).NumberValue,

                (CSV.Tables.Get(Gamefile.Globals).GetData("VILLAGE2_SPEED_UP_DIAMOND_COST_1_MIN") as Globals).NumberValue,
                (CSV.Tables.Get(Gamefile.Globals).GetData("VILLAGE2_SPEED_UP_DIAMOND_COST_1_HOUR") as Globals).NumberValue,
                (CSV.Tables.Get(Gamefile.Globals).GetData("VILLAGE2_SPEED_UP_DIAMOND_COST_24_HOURS") as Globals).NumberValue,
                (CSV.Tables.Get(Gamefile.Globals).GetData("VILLAGE2_SPEED_UP_DIAMOND_COST_1_WEEK") as Globals).NumberValue };
        }

        internal static int SpeedUpCost(int Time)
        {
            if (Time >= 60)
            {
                int MaxTime, MinTime;
                int MaxCost, MinCost;

                if (Time >= 3600)
                {
                    if (Time >= 86400)
                    {
                        MaxCost = Helpers.SpeedUpGemsCost[3];
                        MinCost = Helpers.SpeedUpGemsCost[2];

                        MaxTime = 604800;
                        MinTime = 86400;
                    }
                    else
                    {
                        MaxCost = Helpers.SpeedUpGemsCost[2];
                        MinCost = Helpers.SpeedUpGemsCost[1];

                        MaxTime = 86400;
                        MinTime = 3600;
                    }
                }
                else
                {
                    MaxCost = Helpers.SpeedUpGemsCost[1];
                    MinCost = Helpers.SpeedUpGemsCost[0];

                    MaxTime = 3600;
                    MinTime = 60;
                }

                return (Time - MinTime) * (MaxCost - MinCost) / (MaxTime - MinTime) + MinCost;
            }

            return Helpers.SpeedUpGemsCost[0];
        }

        internal static int ResourceCost(int Count)
        {
            if (Count >= 100)
            {
                int MaxCount, MinCount;
                int MaxCost, MinCost;

                if (Count >= 1000)
                {
                    if (Count >= 10000)
                    {
                        if (Count >= 100000)
                        {
                            if (Count >= 1000000)
                            {
                                MaxCost = Helpers.ResourceGemsCost[5];
                                MinCost = Helpers.ResourceGemsCost[4];

                                MaxCount = 10000000;
                                MinCount = 1000000;
                            }
                            else
                            {
                                MaxCost = Helpers.ResourceGemsCost[4];
                                MinCost = Helpers.ResourceGemsCost[3];

                                MaxCount = 1000000;
                                MinCount = 100000;
                            }
                        }
                        else
                        {
                            MaxCost = Helpers.ResourceGemsCost[3];
                            MinCost = Helpers.ResourceGemsCost[2];

                            MaxCount = 100000;
                            MinCount = 10000;
                        }
                    }
                    else
                    {
                        MaxCost = Helpers.ResourceGemsCost[2];
                        MinCost = Helpers.ResourceGemsCost[1];

                        MaxCount = 10000;
                        MinCount = 1000;
                    }
                }
                else
                {
                    MaxCost = Helpers.ResourceGemsCost[1];
                    MinCost = Helpers.ResourceGemsCost[0];

                    MaxCount = 1000;
                    MinCount = 100;
                }

                return (Count - MinCount) / ((MaxCount - MinCount) / (MaxCost - MinCost)) + MinCost;
            }

            return Helpers.ResourceGemsCost[0];
        }
    }
}
