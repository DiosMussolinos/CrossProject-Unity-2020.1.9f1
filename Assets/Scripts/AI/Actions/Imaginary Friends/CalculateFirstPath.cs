using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Imaginary Friends/Calculate First Path")]
public class CalculateFirstPath : Action
{
    public override void Act(FSM entity)
    {
        entity.GetAgent().CalculateFirstPath();
        entity.GetAgent().isGoingBack = false;
    }
}
