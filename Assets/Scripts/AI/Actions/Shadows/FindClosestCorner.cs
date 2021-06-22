using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Shadows/Find Corner")]
public class FindClosestCorner : Action
{
    public override void Act(FSM entity)
    {
        entity.GetAgent().waypointInCorner = entity.GetAgent().GetClosestCorner().transform;
    }
}
