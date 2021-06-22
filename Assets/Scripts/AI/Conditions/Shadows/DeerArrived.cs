using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Shadows/Deer Arrived")]
public class DeerArrived : Condition
{
    public override bool Validate(FSM entity)
    {
        return entity.GetAgent().deerCountDown >= 1 && entity.GetAgent().imaginaryFriend.ID == 7;

    }
}

