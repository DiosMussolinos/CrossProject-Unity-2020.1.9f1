using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Imaginary Friends/Stroll")]
public class StrollAction : Action
{
    public override void Act(FSM entity)
    {
        entity.GetAgent().Stroll();
        //var agent = entity.GetAgent();
        
        //if (agent.HasReachedFinalTarget())
        //{
        //    return;
        //}
        //if (agent.IsMoving())
        //{
        //    return;
        //}
        //agent.UpdateIFPath();
        //agent.MoveAgent();

        //if (agent.HasReachedEndOfPathOrNoPath())
        //{
        //    agent.UpdateTargets();
        //}
        //else
        //{
        //    agent.IncreaseCurrentWaypoint();
        //}
        // transition: is currTarget > target.count? yes: go back
        // calculate path: path = Pathfinding.FindPath(currWaypoint, targets[target], waypoints)
        // set destination to path
        // reached end of path or no path? 
        // no: increase current waypoint and recalculate path
        // yes: increase target and go to idle

    }
}
