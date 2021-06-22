using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Imaginary Friends/Update Targets")]
public class UpdateTargets : Action
{
    public override void Act(FSM entity)
    {
        entity.GetAgent().UpdateTargets();
    }
}
