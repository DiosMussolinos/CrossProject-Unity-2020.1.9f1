using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Shadows/Patrol")]
public class PatrolAction : Action
{
    public override void Act(FSM entity)
    {
       // entity.GetAgent().DisableCollisionAvoidance();
        entity.GetAgent().imaginaryFriend.InitialSearchTimer = entity.GetAgent().imaginaryFriend.SearchTimer;

        if (entity.GetAgent().imaginaryFriend.ID == ShadowsID.Player && entity.GetAgent().ReachedGoal())
        {
            entity.GetAgent().RandomizeTargets();
        }
        if(entity.GetAgent().imaginaryFriend.ID == ShadowsID.Deer && entity.GetAgent().ReachedGoal())
        {

            entity.GetAgent().deerCountDown += 1;
        }
        if (entity.GetAgent().imaginaryFriend.ID == ShadowsID.Panda && entity.GetAgent().ReachedGoal())
        {
            entity.GetAgent().pandaCountDown += 1;

        }
        
        entity.GetAgent().Patrol();
       
    }
}
