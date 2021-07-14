using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Shadows/Mark Placed")]
public class MarkPlaced : Condition
{
    public override bool Validate(FSM entity)
    {
        return entity.GetAgent().imaginaryFriend.MarkingTimer <= 0 || !entity.GetAgent().marks.Any();
    }
}
