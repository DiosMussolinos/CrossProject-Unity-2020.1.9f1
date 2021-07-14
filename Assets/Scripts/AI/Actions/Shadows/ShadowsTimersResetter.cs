using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Shadows/Shadows Resetter")]
public class ShadowsTimersResetter : Action
{
    public override void Act(FSM entity)
    {
        if(entity.GetAgent().imaginaryFriend.ID == ShadowsID.Cat)
        {
            entity.GetAgent().imaginaryFriend.InitialHidingTimer = entity.GetAgent().imaginaryFriend.HidingTimer;
        }
        if (entity.GetAgent().imaginaryFriend.ID == ShadowsID.Lion)
        {
            entity.GetAgent().imaginaryFriend.MarkingTimer = entity.GetAgent().imaginaryFriend.InitialMarkingTimer;
        }
        if (entity.GetAgent().imaginaryFriend.ID == ShadowsID.Panda)
        {
            if (entity.GetAgent().pandaSleep <= 0)
            {
                entity.GetAgent().pandaSleep = entity.GetAgent().initialPandaSleepTimer;
            }
        }

    }
}
