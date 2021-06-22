using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Shadows/Sleep")]
public class SleepAction : Action
{
    public override void Act(FSM entity)
    {
        //entity.GetAgent().PauseAgent();
        if (entity.GetAgent().pandaCountDown >= 3 && entity.GetAgent().pandaSleep > 0)
        {
            entity.GetAgent().PauseAgent();
            entity.GetAgent().pandaCountDown = 0;
        }
    }
}
