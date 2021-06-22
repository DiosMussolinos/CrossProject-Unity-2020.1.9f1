using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Shadows/RotateDeer")]
public class Rotate : Action
{
    public override void Act(FSM entity)
    {
        if (entity.GetAgent().deerCountDown >= 1 && entity.GetAgent().deerSearch > 0)
        {
            entity.GetAgent().PauseAgent();
            entity.GetAgent().deerCountDown = 0;
        }
    }
}
