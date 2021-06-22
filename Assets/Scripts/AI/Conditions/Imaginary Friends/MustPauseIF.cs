using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Imaginary Friends/Must Pause")]
public class MustPauseIF : Condition
{
    public override bool Validate(FSM entity)
    {
        return entity.GetAgent().HasReachedEndOfPathOrNoPath() && entity.GetAgent().timer > 0;
      
    }
}
