using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Shadows/Finished Hiding")]
public class FinishedHiding : Condition
{
    public override bool Validate(FSM entity)
    {
        return entity.GetAgent().imaginaryFriend.InitialHidingTimer <= 0 && Vector3.Distance(entity.GetAgent().player.transform.position, entity.GetAgent().transform.position) > entity.GetAgent().imaginaryFriend.VisionRange;
    }
}
