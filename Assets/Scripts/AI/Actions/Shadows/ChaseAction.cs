using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Shadows/Chase")]
public class ChaseAction : Action
{
    public override void Act(FSM entity)
    {
        entity.GetAgent().SetDestinationTo(entity.GetAgent().player.transform.position);
        entity.GetAgent().RotationSpeedExtra();
        entity.GetAgent().UpdateSpeed(entity.GetAgent().imaginaryFriend.ChasingSpeed);
        entity.GetAgent().imaginaryFriend.LastPlayerPosition = entity.GetAgent().player.transform.position;
        entity.GetAgent().imaginaryFriend.InitialSearchTimer = entity.GetAgent().imaginaryFriend.SearchTimer;
        entity.GetAgent().imaginaryFriend.InitialChaseTimer -= Time.deltaTime;
        entity.GetAgent().EnableCollisionAvoidance();

        if (entity.GetAgent().imaginaryFriend.ID == 3)
        {
            entity.GetAgent().control.heartBeat += 0.7f * Time.deltaTime;
        }
    
    }
}
