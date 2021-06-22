using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Imaginary Friends/PauseIF")]
public class PauseIF : Action
{
    public override void Act(FSM entity)
    {
        entity.GetAgent().timer -= Time.deltaTime;
    }
}
