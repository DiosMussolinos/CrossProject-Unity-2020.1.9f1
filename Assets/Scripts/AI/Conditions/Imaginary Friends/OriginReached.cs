using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Imaginary Friends/Origin Reached")]
public class OriginReached : Condition
{
    public override bool Validate(FSM entity)
    {
        if (entity.GetAgent().ReachedOrigin())
        {
            return true;
        }
        return false;
    }
}
