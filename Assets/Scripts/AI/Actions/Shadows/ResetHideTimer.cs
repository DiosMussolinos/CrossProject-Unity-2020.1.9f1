using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Shadows/Reset Hide Timer")]
public class ResetHideTimer : Action
{
    public override void Act(FSM entity)
    {
        entity.GetAgent().imaginaryFriend.InitialHidingTimer = entity.GetAgent().imaginaryFriend.HidingTimer;
    }
}
