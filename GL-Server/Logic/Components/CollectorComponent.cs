using GL.Servers.CoC.Files;
using GL.Servers.CoC.Logic.Enums;
using GL.Servers.CoC.Logic.Slots.Items;

namespace GL.Servers.CoC.Logic.Components
{
    internal static class CollectorComponent
    {
        internal static bool Collect(this Building Building)
        {
            if (Building.Csv.ResourcePer100Hours[Building.Level] > 0)
            {
                if (!Building.ConstructionTime.HasValue)
                {
                    int Resource = CSV.Tables.Get(Gamefile.Resources).GetData(Building.Csv.ProducesResource).GlobalID;

                    int RCount = (int)(Building.Csv.ResourcePer100Hours[Building.Level] / 360000f * (Building.Csv.ResourceMax[Building.Level] * 1f / Building.Csv.ResourcePer100Hours[Building.Level] * 360000f - (Building.ResourceTime ?? 0)));

                    int RAdded = Building.Objects.Player.Resources.Plus(Resource, RCount);

                    if (RCount > 0)
                    {
                        if (RAdded < RCount)
                        {
                            Building.ResourceTime += (int)(RAdded * 1f / Building.Csv.ResourcePer100Hours[Building.Level] * 360000f + 1);
                        }
                        else
                        {
                            Building.ResourceTime = (int)(Building.Csv.ResourceMax[Building.Level] * 1f / Building.Csv.ResourcePer100Hours[Building.Level] * 360000f + 1);
                        }
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
