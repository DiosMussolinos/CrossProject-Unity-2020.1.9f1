using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Shadows/Player Lost")]
public class PlayerLost : Condition
{
    public override bool Validate(FSM entity)
    {
        if (entity.GetAgent().imaginaryFriend.ID == ShadowsID.Fox)
        {
            return entity.GetAgent().player.GetComponent<ControlAndMovement>().CollidedWithLight();
        }
        else if (entity.GetAgent().imaginaryFriend.ID == ShadowsID.Lion)
        {
            if (entity.GetAgent().player.GetComponent<ControlAndMovement>().MarkTriggered() != null)
                return Vector3.Distance(entity.GetAgent().player.transform.position, entity.GetAgent().player.GetComponent<ControlAndMovement>().MarkTriggered().transform.position) >= 20f && Vector3.Distance(entity.GetAgent().transform.position, entity.GetAgent().player.transform.position) > entity.GetAgent().imaginaryFriend.VisionRange;
            else
                return entity.GetAgent().player.GetComponent<ControlAndMovement>().CollidedWithLight() || Vector3.Distance(entity.GetAgent().transform.position, entity.GetAgent().player.transform.position) > entity.GetAgent().imaginaryFriend.VisionRange;
        }
        else
        {
            return Vector3.Distance(entity.GetAgent().transform.position, entity.GetAgent().player.transform.position) > entity.GetAgent().imaginaryFriend.VisionRange || entity.GetAgent().player.GetComponent<ControlAndMovement>().CollidedWithLight();
        }
    }
}
