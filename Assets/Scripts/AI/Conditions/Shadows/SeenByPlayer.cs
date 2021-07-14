using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Shadows/Seen by Player")]
public class SeenByPlayer : Condition
{
    public override bool Validate(FSM entity)
    {
        //Debug.Log(entity.GetAgent().player.GetComponent<ControlAndMovement>().CanSeeShadow());
        return entity.GetAgent().player.GetComponent<ControlAndMovement>().CanSeeShadow() && entity.GetAgent().imaginaryFriend.ID == ShadowsID.Cat;
    }
}
