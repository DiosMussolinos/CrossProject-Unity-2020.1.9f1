using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Shadows/Can Attack")]
public class CanAttack : Condition
{
    public override bool Validate(FSM entity)
    {
        return entity.GetAgent().imaginaryFriend.InitialChaseTimer <= 0 && !entity.GetAgent().player.GetComponent<ControlAndMovement>().CollidedWithLight() || Vector3.Distance(entity.GetAgent().transform.position, entity.GetAgent().player.transform.position) < entity.GetAgent().imaginaryFriend.AttackRange;
    }
}
