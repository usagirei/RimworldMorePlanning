using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;
using MorePlanning.Designators;

namespace MorePlanning.Settings
{
    class MorePlanningGameComp : GameComponent
    {
        private bool planningVisibility = true;

        public MorePlanningGameComp(Game game) : base() { }

        public static bool PlanningVisibility
        {
            get => Current.Game.GetComponent<MorePlanningGameComp>().planningVisibility;
            set
            {
                Current.Game.GetComponent<MorePlanningGameComp>().planningVisibility = value;
                VisibilityDesignator.UpdateIconTool(value);
            }
        }

        public override void ExposeData()
        {
            Scribe_Values.Look(ref planningVisibility, "planningVisibility");
        }
        public override void FinalizeInit()
        {
            VisibilityDesignator.UpdateIconTool(planningVisibility);
        }
    }
}
