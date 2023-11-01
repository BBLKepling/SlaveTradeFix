using HarmonyLib;
using RimWorld;

namespace SlaveTradeFix
{
    public class SlaveTradeFix_Slaves
    {
        [HarmonyPatch(typeof(StockGenerator_Slaves), nameof(StockGenerator_Slaves.HandlesThingDef))]
        class Patch
        {
            static bool Prefix(ref bool __result)
            {
                Faction faction = TradeSession.trader.Faction;
                if (faction != null && faction.ideos != null)
                {
                    foreach (Ideo allIdeo in faction.ideos.AllIdeos)
                    {
                        if (!allIdeo.IdeoApprovesOfSlavery())
                        {
                            __result = false;
                            return false;
                        }
                    }
                }
                return true;
            }
        }
    }
}
