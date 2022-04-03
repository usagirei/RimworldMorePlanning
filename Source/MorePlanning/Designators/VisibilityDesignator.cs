using MorePlanning.Utility;
using RimWorld;
using UnityEngine;
using Verse;
using Verse.Sound;
using Resources = MorePlanning.Common.Resources;
using MorePlanning.Settings;

namespace MorePlanning.Designators
{
    public class VisibilityDesignator : BaseDesignator
    {
        public VisibilityDesignator() : base("MorePlanning.PlanVisibility".Translate(), "MorePlanning.PlanVisibilityDesc".Translate())
        {
            soundSucceeded = SoundDefOf.Designate_PlanAdd;
            hotKey = KeyBindingDefOf.Misc12;
        }

        public override AcceptanceReport CanDesignateCell(IntVec3 loc)
        {
            MorePlanningMod.LogError(GetType().Name + " can't designate cells");
            return AcceptanceReport.WasRejected;
        }

        public static void UpdateIconTool(bool visible)
        {
            var desPlanningVisibility = MenuUtility.GetPlanningDesignator<VisibilityDesignator>();

            desPlanningVisibility.icon = visible ? Resources.IconVisible : Resources.IconInvisible;
        }

        public override void ProcessInput(Event ev)
        {
            CurActivateSound?.PlayOneShotOnCamera();
            Find.DesignatorManager.Deselect();
            MorePlanningGameComp.PlanningVisibility = !MorePlanningGameComp.PlanningVisibility;
        }
    }
}
