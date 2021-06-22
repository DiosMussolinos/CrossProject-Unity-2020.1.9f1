using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Shadows/Reset Cat Speed")]

public class ResetSpeedCat : Action
{
    public override void Act(FSM entity)
    {
        entity.GetAgent().UpdateSpeed(entity.GetAgent().imaginaryFriend.Speed);
    }
}
