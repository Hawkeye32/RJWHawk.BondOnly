using HarmonyLib;
using System.Reflection;
using Verse;

namespace RJWHawk.BondOnly
{
    [StaticConstructorOnStartup]
    public static class Startup
    {
        static Startup()
        {
            Harmony.DEBUG = false;
            Harmony harmony = new Harmony("RJWHawk.BondOnly");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}