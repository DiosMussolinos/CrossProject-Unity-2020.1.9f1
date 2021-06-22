using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Imaginary Friends/Reset")]
public class ResetAction : Action
{
    public override void Act(FSM entity)
    {
        //entity.GetAgent().StopAgent();
        if (entity.GetAgent().timer <= 0)
        {
            entity.GetAgent().timer = GetRandTimer();
        }
    }

    private float GetRandTimer()
    {
        return Random.Range(5f, 10f);
    }
}
