using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Shadows/Patrol Deer")]
public class DeerPatrol : Action
{
    public override void Act(FSM entity)
    {
        //DEER RELATED
        entity.GetAgent().RestartDeerTimer();
        entity.GetAgent().ResumeAgent();
    }
}

