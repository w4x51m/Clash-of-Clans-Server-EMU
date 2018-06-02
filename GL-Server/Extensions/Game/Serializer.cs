using System.Collections.Generic;
using GL.Servers.CoC.Extensions.Json;
using GL.Servers.CoC.Logic;
using Newtonsoft.Json;

namespace GL.Servers.CoC.Extensions.Game
{
    internal static class Serializer
    {
        internal static JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            NullValueHandling    = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Include,
            Converters           = new List<JsonConverter> { new FloatConverter() }
        };

        /// <summary>
        /// Gets the json of the <see cref="Objects"/>
        /// </summary>
        /// <param name="Objects"></param>
        /// <returns>The JSON.</returns>
        internal static string Serialize(this Objects Objects)
        {
            return JsonConvert.SerializeObject(new
            {
                exp_ver                 = Objects.ExpVersion,
                active_layout                 = Objects.ActiveLayout,
                active_l2                 = Objects.ActiveLayout2,
                layout_state                 = Objects.LayoutState.Values,
                layout_coldown                 = Objects.LayoutColdown.Values,

                buildings               = Objects.Buildings.Values,
                obstacles               = Objects.Obstacles.Values,
                traps                   = Objects.Traps.Values,
                decos                   = Objects.Decos.Values,

                respawnVars             = Objects.RespawnVariables,
                coldowns             = Objects.Coldowns,

                units             = Objects.Units.Values,
                spells             = Objects.Spells.Values,

                buildings2              = Objects.Buildings2.Values,
                obstacles2              = Objects.Obstacles2.Values,
                traps2                  = Objects.Traps2.Values,
                decos2                  = Objects.Decos2.Values,

                vobjs                   = Objects.VillageObjects.Values,
                vobjs2                   = Objects.Village2Objects.Values,

                v2rs                   = Objects.V2rs,
                tgsec                   = Objects.Tgsec,
                tgseed                   = Objects.Tgseed,

                newShopBuildings                  = Objects.NewShopBuildings.Values,
                newShopTraps                  = Objects.NewShopTraps.Values,
                newShopDecos                  = Objects.NewShopDecos.Values,

                offer                  = Objects.Offer.Values,

                last_league_rank           = Objects.LastLeagueRank,
                last_alliance_level           = Objects.LastAllianceLevel,
                last_league_shuffle           = Objects.LastLeagueShuffle,
                last_season_seen           = Objects.LastSeasonSeen,
                last_news_seen           = Objects.LastNewsSeen,

                troop_req_msg           = Objects.TroopRequestMessage,
                war_req_msg             = Objects.WarRequestMessage,

                war_tutorials_seen           = Objects.WarTutorialsSeen,

                army_names              = Objects.ArmyNames,

                account_flags                  = Objects.AccountFlags,
                events                  = Objects.Events
            }, Serializer.Settings);
        }
    }
}
