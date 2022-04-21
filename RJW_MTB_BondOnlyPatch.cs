// RJWSexperience.Ideology.RJW_Patch_ChancePerHour_Bestiality
using HarmonyLib;
using RimWorld;
using rjw;
using Verse;

namespace RJWHawk.BondOnly
{
[HarmonyPatch(typeof(ThinkNode_ChancePerHour_Bestiality), "MtbHours")]
public static class RJW_Patch_ChancePerHour_Bestiality
{
	public static void Postfix(Pawn pawn, ref float __result)
	{
		Ideo ideo = pawn.Ideo;
		if (ideo != null)
		{
			__result *= BestialityByPrecept(ideo);
		}
	}

	public static float BestialityByPrecept(Ideo ideo)
	{
		if (ideo.HasPrecept(VariousDefOf.Bestiality_BondOnly))
		{
			return 0.5f;
		}
		return 5f;
	}
}
}