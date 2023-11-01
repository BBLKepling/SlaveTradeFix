using HarmonyLib;
using Verse;

namespace SlaveTradeFix
{
    [StaticConstructorOnStartup]
    public static class HarmonyInit
    {
        static HarmonyInit()
        {
            Harmony harmonyInstance = new Harmony("BBLKepling.SlaveTradeFix");
            harmonyInstance.PatchAll();
        }
    }
}
