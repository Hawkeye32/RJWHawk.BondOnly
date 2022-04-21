// RJWSexperience.Ideology.RJW_Patch_would_fuck
using System;
using HarmonyLib;
using RimWorld;
using rjw;
using Verse;

namespace RJWHawk.BondOnly
{
	[HarmonyPatch(typeof(SexAppraiser), "would_fuck", new Type[]
	{
	typeof(Pawn),
	typeof(Pawn),
	typeof(bool),
	typeof(bool),
	typeof(bool)
	})]
	public static class RJW_Patch_would_fuck
	{
		public static void Postfix(Pawn fucker, Pawn fucked, bool invert_opinion, bool ignore_bleeding, bool ignore_gender, ref float __result)
		{
			if (!xxx.is_human(fucker))
			{
				return;
			}
			Ideo ideo = fucker.Ideo;
			if (ideo == null)
			{
				Log.Message("test1");
				return;
			}
			if (!fucked.IsAnimal())
			{
				return;
			}
			if (ideo.HasPrecept(RJWHawk.BondOnly.VariousDefOf.Bestiality_BondOnly))	
			{
				Pawn_RelationsTracker animalrelations = fucker.relations;
				if (animalrelations != null && animalrelations.DirectRelationExists(PawnRelationDefOf.Bond, fucked))
				{
					__result *= 2f;
				}
				else
                {
					__result *= 0.1f;
                }
			
			}
			
		}
	}
}
