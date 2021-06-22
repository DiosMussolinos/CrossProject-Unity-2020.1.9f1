using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Imaginary Friends/Update Path")]
public class UpdatePathAction : Action
{
    public override void Act(FSM entity)
    {
        entity.GetAgent().UpdatePath();
    }
}
