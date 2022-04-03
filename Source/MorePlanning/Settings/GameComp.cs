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
            get
            {
                if (Current.Game.GetComponent<MorePlanningGameComp>().planningVisibility)
                    return true;

                if (Find.DesignatorManager.SelectedDesignator is Designator des &&
                    (des is Designator_Build ||
                    des is Designator_Claim ||
                    des is Designator_Deconstruct ||
                    des is Designator_Install ||
                    des is Designator_Plan ||
                    des is Designator_SmoothSurface ||
                    des is Designator_Uninstall ||
                    des is BaseDesignator))
                {
                    return true;
                }
                return false;
            }
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
