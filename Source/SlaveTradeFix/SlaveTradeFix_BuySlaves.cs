using HarmonyLib;
using RimWorld;

namespace SlaveTradeFix
{
    public class SlaveTradeFix_BuySlaves
    {
        [HarmonyPatch(typeof(StockGenerator_BuySlaves), nameof(StockGenerator_BuySlaves.HandlesThingDef))]
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
