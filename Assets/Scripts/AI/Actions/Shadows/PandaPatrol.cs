using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Shadows/Patrol Panda")]
public class PandaPatrol : Action
{
    public override void Act(FSM entity)
    {
        //PANDA RELATED
        entity.GetAgent().RestartPandaTimer();
        entity.GetAgent().ResumeAgent();
    }
}
