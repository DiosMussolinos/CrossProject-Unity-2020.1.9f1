using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Shadows/Reset Sleep")]
public class ResetSleepTimer : Action
{
    public override void Act(FSM entity)
    {
        //entity.GetAgent().pandaSleep = entity.GetAgent().initialSleepTimer;
        if (entity.GetAgent().pandaSleep <= 0)
        {
            entity.GetAgent().pandaSleep = entity.GetAgent().initialPandaSleepTimer;
        }
        //entity.GetAgent().pandaSleep = entity.GetAgent().initialPandaSleepTimer;
    }
}
