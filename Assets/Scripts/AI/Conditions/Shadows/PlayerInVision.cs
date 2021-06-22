using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Shadows/Player In Vision")]
public class PlayerInVision : Condition
{
    public bool isInVision;
    public override bool Validate(FSM entity)
    {
        if (Vector3.Distance(entity.GetAgent().player.transform.position, entity.GetAgent().transform.position) < entity.GetAgent().imaginaryFriend.VisionRange && !entity.GetAgent().player.GetComponent<ControlAndMovement>().CollidedWithLight() && entity.GetAgent().imaginaryFriend.ID != 1)
        {
            return isInVision;
        }
        
        return !isInVision;
    }
}
