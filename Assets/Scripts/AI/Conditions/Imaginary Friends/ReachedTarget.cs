using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Imaginary Friends/Target Reached")]
public class ReachedTarget : Condition
{
    public override bool Validate(FSM entity)
    {
        if (entity.GetAgent().IsPathStalled())
        {
            if (entity.GetAgent().HasReachedFinalTarget())
            {
                return true;
            }
        }
        return false;
    }
}
